<template>
  <component
    :is="isTextarea ? 'textarea' : 'input'"
    :value="modelValue"
    class="base-input"
    :class="{ error: isError }"
    :aria-disabled="disabled"
    :aria-readonly="readonly"
    @input="onInput"
  />
</template>

<script setup>
const props = defineProps({
  modelValue: {
    type: String,
    required: false,
    default: "",
  },
  isError: {
    type: Boolean,
    default: false,
  },
  isTextarea: {
    type: Boolean,
    default: false,
  },
  disabled: {
    type: Boolean,
    default: false,
  },
  readonly: {
    type: Boolean,
    default: false,
  },
  emptyAsNull: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(["update:modelValue"]);

const onInput = (e) => {
  emit(
    "update:modelValue",
    e.target.value || !props.emptyAsNull ? e.target.value : null
  );
};
</script>

<style lang="scss">
.base-input {
  width: 100%;
  padding: 13px 16px;
  color: black;
  font-size: 16px;
  border: 1px solid $light-gray-color;
  border-radius: 6px;
  resize: none;

  &::placeholder {
    color: $gray-color;
  }

  &.error {
    border-color: red;
  }
}
</style>
