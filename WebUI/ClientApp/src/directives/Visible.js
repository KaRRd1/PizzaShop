export default {
  mounted(el, binding) {
    const options = {
      rootMargin: `${el.offsetHeight}px 0px 0px 0px`,
      threshold: 1,
    };

    const callback = (entries) => {
      binding.value(entries[0].intersectionRatio === 1);
    };

    const observer = new IntersectionObserver(callback, options);
    observer.observe(el);
  },
};
