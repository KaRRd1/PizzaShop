export default {
  mounted(el, binding) {
    el.clickOutsideEvent = (e) => {
      e.stopPropagation();

      if (el !== e.target && !el.contains(e.target)) {
        binding.value();
      }
    };

    document.addEventListener("click", el.clickOutsideEvent);
  },
  unmounted(el) {
    document.removeEventListener("click", el.clickOutsideEvent);
  },
};
