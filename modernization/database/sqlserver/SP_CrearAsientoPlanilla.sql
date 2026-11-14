USE [Sic_Local_Web];
GO

SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

-- Combina las líneas de Administrativo, Ventas y Reparto en un único resultado.
-- Aplicar después de SP_CrearAsientoPlanilla_Reparto.sql.
ALTER PROCEDURE [dbo].[SP_CrearAsientoPlanilla]
    @IdPlanilla INTEGER,
    @pCodError VARCHAR(5) OUTPUT,
    @pMensajeError VARCHAR(300) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @v_variable_seguimiento VARCHAR(4) = '00';
    DECLARE @cCodigoError VARCHAR(2) = '99';
    DECLARE @return_value INTEGER;

    BEGIN TRY
        CREATE TABLE #AsientoAdministrativoTemp
        (
            NumeroCuenta VARCHAR(100),
            Descripcion VARCHAR(100),
            Debit DECIMAL(18, 6),
            Credit DECIMAL(18, 6),
            NormaReparto VARCHAR(10)
        );

        CREATE TABLE #AsientoVentasTemp
        (
            NumeroCuenta VARCHAR(100),
            Descripcion VARCHAR(100),
            Debit DECIMAL(18, 6),
            Credit DECIMAL(18, 6),
            NormaReparto VARCHAR(10)
        );

        -- Esta tabla temporal también está disponible durante la llamada a Reparto.
        CREATE TABLE #AsientoRepartoTemp
        (
            NumeroCuenta VARCHAR(100),
            Descripcion VARCHAR(100),
            Debit DECIMAL(18, 6),
            Credit DECIMAL(18, 6),
            NormaReparto VARCHAR(10)
        );

        SET @v_variable_seguimiento = '01';

        INSERT INTO #AsientoAdministrativoTemp
        (
            NumeroCuenta,
            Descripcion,
            Debit,
            Credit,
            NormaReparto
        )
        EXEC @return_value = [dbo].[SP_CrearAsientoPlanilla_Administrativo]
            @IdPlanilla = @IdPlanilla,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        SET @v_variable_seguimiento = '02';

        INSERT INTO #AsientoVentasTemp
        (
            NumeroCuenta,
            Descripcion,
            Debit,
            Credit,
            NormaReparto
        )
        EXEC @return_value = [dbo].[SP_CrearAsientoPlanilla_Ventas]
            @IdPlanilla = @IdPlanilla,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        SET @v_variable_seguimiento = '03';

        -- Reparto contiene INSERT ... EXEC internos; por eso la llamada exterior es EXEC.
        EXEC @return_value = [dbo].[SP_CrearAsientoPlanilla_Reparto]
            @IdPlanilla = @IdPlanilla,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT,
            @GuardarEnTablaPadre = 1;

        IF @pCodError <> '00'
        BEGIN
            RETURN;
        END;

        -- UNION ALL conserva cada línea contable, incluso si comparte cuenta con otra sección.
        SELECT NumeroCuenta, Descripcion, Debit, Credit, NormaReparto
        FROM #AsientoAdministrativoTemp

        UNION ALL

        SELECT NumeroCuenta, Descripcion, Debit, Credit, NormaReparto
        FROM #AsientoVentasTemp

        UNION ALL

        SELECT NumeroCuenta, Descripcion, Debit, Credit, NormaReparto
        FROM #AsientoRepartoTemp;
    END TRY
    BEGIN CATCH
        SET @pCodError = @cCodigoError;
        SET @pMensajeError =
            'Error inesperado en [SP_CrearAsientoPlanilla] en '
            + @v_variable_seguimiento
            + ' - '
            + CAST(ERROR_NUMBER() AS VARCHAR(10))
            + ' - '
            + ERROR_MESSAGE();
    END CATCH;
END;
GO
