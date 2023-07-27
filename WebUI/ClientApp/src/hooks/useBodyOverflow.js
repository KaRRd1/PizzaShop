import { watch } from "vue";

export const useBodyOverflow = (booleanStateToWatch, className = null) => {
  const stopWatch = watch(
    () => booleanStateToWatch.value,
    () => {
      if (booleanStateToWatch.value) addOverflowHidden();
      else removeOverflowHidden();
    }
  );

  const addOverflowHidden = () => {
    if (className) {
      document.body.classList.add(className);
    } else {
      document.body.style.overflow = "hidden";
    }
  };

  const removeOverflowHidden = () => {
    if (className) {
      document.body.classList.remove(className);
    } else {
      document.body.style.overflow = "";
    }
  };

  return {
    stopWatch,
  };
};
