/**
 * Confirma los cambios operativos y evita envíos duplicados mientras responde el servidor.
 */
const transmissionPage = document.querySelector(".transmission-page");
const agentEntry = document.getElementById("transmission-agent-entry");

document.querySelectorAll(".transmission-clear-form").forEach((form) => {
    form.addEventListener("submit", (event) => {
        const agent = agentEntry.value.trim();
        if (!/^[0-9]{1,30}$/.test(agent)) {
            event.preventDefault();
            agentEntry.focus();
            window.alert("Indique el número de agente antes de limpiar resultados.");
            return;
        }

        const status = form.dataset.clearStatus;
        const confirmation = window.prompt(
            `Se eliminarán los registros ${status} del agente ${agent}. Escriba LIMPIAR para confirmar:`
        );
        if (confirmation !== "LIMPIAR") {
            event.preventDefault();
            return;
        }

        form.querySelector('input[name="agent"]').value = agent;
        form.querySelector('input[name="confirmation"]').value = confirmation;
    });
});

/**
 * Copia el agente visible a los formularios de envío y valida su rango antes del POST.
 */
document.querySelectorAll(".transmission-dispatch-form").forEach((form) => {
    form.addEventListener("submit", (event) => {
        const agent = agentEntry.value.trim();
        if (!/^[0-9]{1,10}$/.test(agent) || Number(agent) > 2147483647) {
            event.preventDefault();
            agentEntry.focus();
            window.alert("Indique un número de agente válido antes de transmitir.");
            return;
        }

        form.querySelector('input[name="agent"]').value = agent;
    });
});

document.querySelectorAll(".transmission-page form[method='post']").forEach((form) => {
    form.addEventListener("submit", (event) => {
        if (event.defaultPrevented) {
            return;
        }

        const message = form.dataset.confirmMessage;
        if (message && !window.confirm(message)) {
            event.preventDefault();
            return;
        }

        const button = event.submitter;
        if (button) {
            button.disabled = true;
            button.textContent = "Procesando…";
        }
    });
});

/**
 * Refresca las señales que WinForms consultaba con Timer sin recargar el grid.
 */
async function refreshTransmissionSignals() {
    if (document.hidden || !transmissionPage) {
        return;
    }

    try {
        const response = await fetch(transmissionPage.dataset.signalsUrl, {
            credentials: "same-origin",
            cache: "no-store"
        });
        if (!response.ok) {
            return;
        }

        const signals = await response.json();
        document.getElementById("transmission-active-agent").textContent = signals.activeAgent ?? "-";
        document.getElementById("transmission-process").textContent = signals.currentProcess ?? "Sin información";

        const today = document.getElementById("transmission-today");
        today.textContent = signals.todayBlocked === true
            ? "HOY BLOQUEADO"
            : signals.todayBlocked === false ? "HOY DESBLOQUEADO" : "HOY SIN INFORMACIÓN";
        today.classList.toggle("transmission-indicator-error", signals.todayBlocked === true);
        today.classList.toggle("transmission-indicator-success", signals.todayBlocked === false);
        today.classList.toggle("transmission-indicator-neutral", signals.todayBlocked === null);

        const source = document.getElementById("transmission-source");
        source.textContent = signals.downloadFromFtp === true
            ? "FTP"
            : signals.downloadFromFtp === false ? "LOCAL" : "Origen desconocido";
        source.classList.toggle("transmission-indicator-success", signals.downloadFromFtp === true);
        source.classList.toggle("transmission-indicator-error", signals.downloadFromFtp === false);
        source.classList.toggle("transmission-indicator-neutral", signals.downloadFromFtp === null);

        const alerts = document.getElementById("transmission-ftp-alerts");
        alerts.replaceChildren();
        for (const message of signals.ftpAlerts ?? []) {
            const line = document.createElement("div");
            line.textContent = message;
            alerts.append(line);
        }
        alerts.hidden = alerts.childElementCount === 0;
    } catch {
        // La última lectura visible permanece hasta la siguiente consulta correcta.
    }
}

if (transmissionPage) {
    window.setInterval(refreshTransmissionSignals, 15000);
}
