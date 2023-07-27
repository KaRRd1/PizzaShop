<template>
  <label class="base-checkbox-btn">
    <input v-model="model" :value="value" type="checkbox" />
    <span class="base-checkbox-btn__content" v-bind="$attrs">
      <slot></slot>
    </span>
  </label>
</template>

<script>
export default {
  inheritAttrs: false,
};
</script>

<script setup>
import { computed } from "vue";

const props = defineProps({
  modelValue: {
    type: [Array, String, Number, Boolean],
    default: "",
  },
  value: {
    type: [String, Number, Object],
    default: "",
  },
});

const emit = defineEmits(["update:modelValue"]);
const model = computed({
  get() {
    return props.modelValue;
  },
  set(value) {
    emit("update:modelValue", value);
  },
});
</script>

<style lang="scss">
.base-checkbox-btn {
  &__content {
    height: 48px;
    //margin: 0 8px 8px 0;
    padding: 0 16px;
    color: black;
    //font-size: 14px;
    background-color: white;
    border: 1px solid $light-gray-color;
    border-radius: 6px;
    cursor: pointer;
    transition: 0.1s ease-in-out;
    @include d-flex($align-items: center);
  }

  input[type="checkbox"] {
    position: absolute;
    display: none;

    &:checked + .base-checkbox-btn__content {
      color: white;
      background-color: $primary-color;
      border-color: $primary-color;
    }
  }
}
</style>
