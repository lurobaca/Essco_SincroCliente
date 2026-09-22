const currentNavigationItems = Array.from(
    document.querySelectorAll(".erp-nav-item[aria-current='page']"));

// Algunas funciones WinForms comparten temporalmente una página Web parcial.
// Se destaca la primera coincidencia del catálogo para no mostrar varias opciones activas.
currentNavigationItems.slice(1).forEach(item => {
    item.classList.remove("erp-nav-item--current");
    item.removeAttribute("aria-current");
});

const currentItem = currentNavigationItems[0];
const navigation = currentItem?.closest(".erp-navigation");
if (currentItem && navigation) {
    navigation.querySelectorAll("details").forEach(group => {
        if (group.contains(currentItem)) {
            group.setAttribute("open", "");
        }
    });
}
