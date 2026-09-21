document.querySelectorAll(".erp-nav-item[aria-current='page']").forEach(item => {
    item.closest("details")?.setAttribute("open", "");
});
