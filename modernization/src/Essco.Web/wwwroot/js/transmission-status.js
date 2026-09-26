/**
 * Confirma los cambios operativos y evita envíos duplicados mientras responde el servidor.
 */
document.querySelectorAll(".transmission-page form[method='post']").forEach((form) => {
    form.addEventListener("submit", (event) => {
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
