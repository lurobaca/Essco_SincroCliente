USE [Sic_Local_Web];
GO

SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

-- Genera las líneas contables de Reparto. La llamada individual conserva cuatro columnas.
-- El procedimiento principal usa la tabla temporal compartida para evitar INSERT ... EXEC anidados.
ALTER PROCEDURE [dbo].[SP_CrearAsientoPlanilla_Reparto]
    @IdPlanilla INTEGER,
    @pCodError VARCHAR(5) OUTPUT,
    @pMensajeError VARCHAR(300) OUTPUT,
    @GuardarEnTablaPadre BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @v_variable_seguimiento VARCHAR(4);
    DECLARE @cCodigoExito VARCHAR(2) = '00';
    DECLARE @cCodigoError VARCHAR(2) = '99';
    DECLARE @pReturn VARCHAR(2) = '99';
    DECLARE @EstadoDePlanilla INTEGER = 0;

    DECLARE @Total_Aguinaldo FLOAT;
    DECLARE @Total_CCSS_Patrono FLOAT;
    DECLARE @Total_Cesantia FLOAT;
    DECLARE @Total_SalarioBrutoQuincenal FLOAT;
    DECLARE @Total_SalarioNetoFinalQuincenal FLOAT;
    DECLARE @Total_SalarioNetoFinalQuincenalAdministrativo FLOAT;
    DECLARE @Total_SalarioNetoFinalQuincenalAgentes FLOAT;
    DECLARE @Total_SalarioNetoFinalQuincenalRutas FLOAT;
    DECLARE @Total_FacturasLliquidaciones FLOAT;
    DECLARE @Total_CCSS_Empleado FLOAT;
    DECLARE @Total_Renta FLOAT;
    DECLARE @Total_Liquidaciones FLOAT;
    DECLARE @Total_Facturas FLOAT;

    DECLARE @AGUINALDOS VARCHAR(50) = '60100303007';
    DECLARE @CARGAS_SOCIALES VARCHAR(50) = '60100303003';
    DECLARE @CESANTIA_PREAVISO VARCHAR(50) = '60100303006';
    DECLARE @SALARIO_BRUTO VARCHAR(50) = '60100101001';
    DECLARE @PROVISIONES_AGUINALDO VARCHAR(50) = '20101201001';
    DECLARE @CARGAS_SOCIALES_CCSS VARCHAR(50) = '20100801005';
    DECLARE @PROVISIONES_CESANTIA VARCHAR(50) = '20101201002';
    DECLARE @SALARIOS_NETO_POR_PAGAR VARCHAR(50) = '20100801001';
    DECLARE @CAJA_GENERAL_COL VARCHAR(50) = '10100101001';
    DECLARE @IMPUESTO_RENTA_SOBRE_SALARIOS VARCHAR(50) = '20100302003';
    DECLARE @BANCO_POPULAR_DED_SAL VARCHAR(50) = '20100302005';
    DECLARE @EMBARGOS VARCHAR(50) = '20100302002';
    DECLARE @PENSIONES_ALIMENTARIAS VARCHAR(50) = '20100302001';
    DECLARE @VIATICOS_AGENTES_DISPLAY_SUP VARCHAR(50) = '60100202028';
    DECLARE @SALARIOS VARCHAR(50) = '60100303002';

    DECLARE @CategoriaEmpleado VARCHAR(15) = 'Reparto';
    DECLARE @PlanillaFechaINI DATE;
    DECLARE @PlanillaFechaFIN DATE;

    BEGIN TRY
        SET @PlanillaFechaINI =
        (
            SELECT T0.FechaINI
            FROM Planilla AS T0
            WHERE T0.Consecutivo = @IdPlanilla
        );

        SET @PlanillaFechaFIN =
        (
            SELECT T0.FechaFIN
            FROM Planilla AS T0
            WHERE T0.Consecutivo = @IdPlanilla
        );

        PRINT 'Obtiene estado de la planilla';

        SET @EstadoDePlanilla =
        (
            SELECT Estado
            FROM Planilla
            WHERE Consecutivo = @IdPlanilla
        );

        SET @v_variable_seguimiento = '01';
        SET @v_variable_seguimiento = '02';
        SET @v_variable_seguimiento = '03';
        SET @v_variable_seguimiento = '04';

        -- Se conserva el cálculo heredado del salario bruto quincenal.
        SET @Total_SalarioBrutoQuincenal =
        (
            SELECT SUM([Salario]) / 2 AS Total
            FROM [dbo].[Planilla_Empleados]
            WHERE [Id_Planilla] = @IdPlanilla
                AND CategoriaEmpleado = @CategoriaEmpleado
        );

        SET @v_variable_seguimiento = '05';
        SET @v_variable_seguimiento = '06';

        SET @Total_FacturasLliquidaciones =
        (
            SELECT SUM(ROUND(T0.Total, 2)) AS Total
            FROM
            (
                SELECT SUM([DocSaldo]) AS Total
                FROM [dbo].[Planilla_Facturas]
                WHERE [Id_Planilla] = @IdPlanilla
                    AND [Estado] = '0'

                UNION ALL

                SELECT SUM([Monto]) AS Total
                FROM [dbo].[Planilla_Liquidaciones]
                WHERE [Id_Planilla] = @IdPlanilla
                    AND [Estado] = '0'
            ) AS T0
        );

        SET @v_variable_seguimiento = '07';
        SET @v_variable_seguimiento = '08';

        SET @Total_Renta =
        (
            SELECT SUM(ROUND(T0.[Monto], 2)) AS Total
            FROM [dbo].[Planilla_DeduccionRenta] AS T0
            WHERE T0.[Id_Planilla] = @IdPlanilla
                AND T0.[Cedula_Empleado] IN
                (
                    SELECT Cedula
                    FROM [dbo].[Planilla_Empleados]
                    WHERE [Id_Planilla] = @IdPlanilla
                        AND CategoriaEmpleado = @CategoriaEmpleado
                )
        );

        SET @v_variable_seguimiento = '09';
        SET @v_variable_seguimiento = '10';

        SET @Total_Liquidaciones =
        (
            SELECT SUM(ROUND([Monto], 2)) AS Total
            FROM [dbo].[Planilla_Liquidaciones]
            WHERE [Id_Planilla] = @IdPlanilla
                AND [Estado] = '0'
                AND [Cedula_Empleado] IN
                (
                    SELECT Cedula
                    FROM [dbo].[Planilla_Empleados]
                    WHERE [Id_Planilla] = @IdPlanilla
                        AND CategoriaEmpleado = @CategoriaEmpleado
                )
        );

        SET @v_variable_seguimiento = '11';

        CREATE TABLE #TblTempSalarios
        (
            NumeroCuenta VARCHAR(50),
            Descripcion VARCHAR(50),
            Debit FLOAT,
            Credit FLOAT
        );

        CREATE INDEX INDEXNumeroCuenta_TblTempSalarios
            ON #TblTempSalarios (NumeroCuenta);

        CREATE TABLE #TblTempAguinaldos
        (
            NumeroCuenta VARCHAR(50),
            Descripcion VARCHAR(50),
            Debit FLOAT,
            Credit FLOAT
        );

        CREATE INDEX INDEXNumeroCuenta_TblTempAguinaldos
            ON #TblTempAguinaldos (NumeroCuenta);

        CREATE TABLE #TblTempCargarSocialesEmpleado
        (
            NumeroCuenta VARCHAR(50),
            Descripcion VARCHAR(50),
            Debit FLOAT,
            Credit FLOAT
        );

        CREATE INDEX INDEXNumeroCuenta_TblTempCargarSocialesEmpleado
            ON #TblTempCargarSocialesEmpleado (NumeroCuenta);

        CREATE TABLE #TblTempCargarSocialesPatrono
        (
            NumeroCuenta VARCHAR(50),
            Descripcion VARCHAR(50),
            Debit FLOAT,
            Credit FLOAT
        );

        CREATE INDEX INDEXNumeroCuenta_TblTempCargarSocialesPatrono
            ON #TblTempCargarSocialesPatrono (NumeroCuenta);

        CREATE TABLE #TblTempCesantiaPreaviso
        (
            NumeroCuenta VARCHAR(50),
            Descripcion VARCHAR(50),
            Debit FLOAT,
            Credit FLOAT
        );

        CREATE INDEX INDEXNumeroCuenta_TblTempCesantiaPreaviso
            ON #TblTempCesantiaPreaviso (NumeroCuenta);

        -- Se mantienen las cinco consultas heredadas; ya no existe INSERT ... EXEC exterior.
        INSERT INTO #TblTempSalarios
        EXEC [dbo].[SP_CrearAsientoPlanilla_Reparto_GetSalariosAgentes]
            @IdPlanilla = @IdPlanilla,
            @PlanillaFechaINI = @PlanillaFechaINI,
            @PlanillaFechaFIN = @PlanillaFechaFIN,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        INSERT INTO #TblTempAguinaldos
        EXEC [dbo].[SP_CrearAsientoPlanilla_Reparto_GetAguinaldosAgentes]
            @IdPlanilla = @IdPlanilla,
            @PlanillaFechaINI = @PlanillaFechaINI,
            @PlanillaFechaFIN = @PlanillaFechaFIN,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        INSERT INTO #TblTempCargarSocialesEmpleado
        EXEC [dbo].[SP_CrearAsientoPlanilla_Reparto_GetCargarSocialesAgentes]
            @IdPlanilla = @IdPlanilla,
            @PlanillaFechaINI = @PlanillaFechaINI,
            @PlanillaFechaFIN = @PlanillaFechaFIN,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        INSERT INTO #TblTempCesantiaPreaviso
        EXEC [dbo].[SP_CrearAsientoPlanilla_Reparto_GetCesantiaPreavisoAgentes]
            @IdPlanilla = @IdPlanilla,
            @PlanillaFechaINI = @PlanillaFechaINI,
            @PlanillaFechaFIN = @PlanillaFechaFIN,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        INSERT INTO #TblTempCargarSocialesPatrono
        EXEC [dbo].[SP_CrearAsientoPlanilla_Reparto_GetCargarSocialesPatronales]
            @IdPlanilla = @IdPlanilla,
            @PlanillaFechaINI = @PlanillaFechaINI,
            @PlanillaFechaFIN = @PlanillaFechaFIN,
            @pCodError = @pCodError OUTPUT,
            @pMensajeError = @pMensajeError OUTPUT;

        SET @Total_Facturas =
        (
            SELECT SUM(ROUND([DocSaldo], 2)) AS Total
            FROM [dbo].[Planilla_Facturas]
            WHERE Id_Planilla = @IdPlanilla
                AND [Estado] = '0'
                AND [Cedula_Empleado] IN
                (
                    SELECT Cedula
                    FROM [dbo].[Planilla_Empleados]
                    WHERE [Id_Planilla] = @IdPlanilla
                        AND CategoriaEmpleado = @CategoriaEmpleado
                )
        );

        IF @Total_Facturas IS NULL
        BEGIN
            SET @Total_Facturas = 0;
        END;

        SET @Total_CCSS_Empleado =
        (
            SELECT ROUND(SUM(T99.[Debit]), 2) AS Debit
            FROM #TblTempCargarSocialesEmpleado AS T99
        );

        IF @Total_CCSS_Empleado IS NULL
        BEGIN
            SET @Total_CCSS_Empleado = 0;
        END;

        SET @Total_Aguinaldo =
        (
            SELECT ROUND(SUM(T99.[Debit]), 2) AS Debit
            FROM #TblTempAguinaldos AS T99
        );

        IF @Total_Aguinaldo IS NULL
        BEGIN
            SET @Total_Aguinaldo = 0;
        END;

        SET @Total_Cesantia =
        (
            SELECT ROUND(SUM(T99.[Debit]), 2) AS Debit
            FROM #TblTempCesantiaPreaviso AS T99
        );

        IF @Total_Cesantia IS NULL
        BEGIN
            SET @Total_Cesantia = 0;
        END;

        SET @Total_CCSS_Patrono =
        (
            SELECT ROUND(SUM(T99.[Debit]), 2) AS Debit
            FROM #TblTempCargarSocialesPatrono AS T99
        );

        IF @Total_CCSS_Patrono IS NULL
        BEGIN
            SET @Total_CCSS_Patrono = 0;
        END;

        SET @Total_SalarioNetoFinalQuincenal =
        (
            SELECT ROUND(SUM(T99.[Debit]), 2) AS Debit
            FROM #TblTempSalarios AS T99
        );

        IF @Total_SalarioNetoFinalQuincenal IS NULL
        BEGIN
            SET @Total_SalarioNetoFinalQuincenal = 0;
        END;

        -- La resta se conserva exactamente como en el procedimiento heredado.
        SET @Total_SalarioNetoFinalQuincenal =
            @Total_SalarioNetoFinalQuincenal
            - @Total_Facturas
            - @Total_CCSS_Empleado;

        -- Se materializan una sola vez las cuatro columnas originales de Reparto.
        SELECT
            T0.NumeroCuenta,
            T0.Descripcion,
            T0.Debit,
            T0.Credit
        INTO #ResultadoReparto
        FROM
        (
            SELECT
                @SALARIOS AS NumeroCuenta,
                'SALARIOS' AS Descripcion,
                ROUND(T99.[Debit], 2) AS Debit,
                ROUND(T99.[Credit], 2) AS Credit
            FROM #TblTempSalarios AS T99

            UNION ALL

            SELECT
                @AGUINALDOS AS NumeroCuenta,
                'AGUINALDOS' AS Descripcion,
                ROUND(T99.[Debit], 2) AS Debit,
                ROUND(T99.[Credit], 2) AS Credit
            FROM #TblTempAguinaldos AS T99

            UNION ALL

            SELECT
                @CARGAS_SOCIALES AS NumeroCuenta,
                'CARGAS SOCIALES' AS Descripcion,
                ROUND(T99.[Debit], 2) AS Debit,
                ROUND(T99.[Credit], 2) AS Credit
            FROM #TblTempCargarSocialesPatrono AS T99

            UNION ALL

            SELECT
                @CESANTIA_PREAVISO AS NumeroCuenta,
                'CESANTIA Y PREAVISO' AS Descripcion,
                ROUND(T99.[Debit], 2) AS Debit,
                ROUND(T99.[Credit], 2) AS Credit
            FROM #TblTempCesantiaPreaviso AS T99

            UNION ALL

            SELECT
                [NumeroCuenta],
                [Descripcion],
                0 AS Debit,
                CASE
                    WHEN [NumeroCuenta] = @SALARIOS_NETO_POR_PAGAR
                        THEN @Total_SalarioNetoFinalQuincenal
                    ELSE
                        CASE
                            WHEN [NumeroCuenta] = @PROVISIONES_AGUINALDO
                                THEN @Total_Aguinaldo
                            ELSE
                                CASE
                                    WHEN [NumeroCuenta] = @CARGAS_SOCIALES_CCSS
                                        AND Descripcion = 'CARGAS_SOCIALES_CCSS_Patrono'
                                        THEN @Total_CCSS_Patrono
                                    ELSE
                                        CASE
                                            WHEN [NumeroCuenta] = @CARGAS_SOCIALES_CCSS
                                                AND Descripcion = 'CARGAS_SOCIALES_CCSS_Empleado'
                                                THEN @Total_CCSS_Empleado
                                            ELSE
                                                CASE
                                                    WHEN [NumeroCuenta] = @PROVISIONES_CESANTIA
                                                        THEN @Total_Cesantia
                                                    ELSE
                                                        CASE
                                                            WHEN [NumeroCuenta] = @IMPUESTO_RENTA_SOBRE_SALARIOS
                                                                THEN @Total_Renta
                                                            ELSE
                                                                CASE
                                                                    WHEN [NumeroCuenta] = @CAJA_GENERAL_COL
                                                                        THEN @Total_Facturas
                                                                    ELSE 0
                                                                END
                                                        END
                                                END
                                        END
                                END
                        END
                END AS Credit
            FROM [dbo].[Planilla_CuentasContables]
            WHERE [Asiento] = @CategoriaEmpleado
        ) AS T0
        WHERE (T0.Credit + T0.Debit) <> 0;

        IF @GuardarEnTablaPadre = 1
        BEGIN
            -- El valor 0 completa la quinta columna solicitada solo en el resultado combinado.
            INSERT INTO #AsientoRepartoTemp
            (
                NumeroCuenta,
                Descripcion,
                Debit,
                Credit,
                NormaReparto
            )
            SELECT
                NumeroCuenta,
                Descripcion,
                Debit,
                Credit,
                '0' AS NormaReparto
            FROM #ResultadoReparto;
        END
        ELSE
        BEGIN
            SELECT
                NumeroCuenta,
                Descripcion,
                Debit,
                Credit
            FROM #ResultadoReparto;
        END;

        PRINT 'Eliminar las tablas temporales';

        DROP TABLE #ResultadoReparto;
        DROP TABLE #TblTempSalarios;
        DROP TABLE #TblTempAguinaldos;
        DROP TABLE #TblTempCargarSocialesEmpleado;
        DROP TABLE #TblTempCargarSocialesPatrono;
        DROP TABLE #TblTempCesantiaPreaviso;
    END TRY
    BEGIN CATCH
        SET @pCodError = @cCodigoError;
        SET @pMensajeError =
            'Error inesperado en [SP_CrearAsientoPlanilla_Reparto] en '
            + @v_variable_seguimiento
            + ' - '
            + CAST(ERROR_NUMBER() AS VARCHAR(10))
            + ' - '
            + ERROR_MESSAGE();
    END CATCH;
END;
GO
