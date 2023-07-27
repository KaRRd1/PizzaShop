<template>
  <div class="base-input-group">
    <label
      class="base-input-group__label"
      :for="inputId"
      :class="{ error: errorMessage }"
    >
      {{ label }}
    </label>
    <slot />
    <span v-show="errorMessage" class="base-input-group__error">
      {{ errorMessage }}
    </span>
  </div>
</template>

<script>
export default {
  name: "BaseInputGroup",
  props: {
    label: {
      type: String,
      required: true,
    },
    errorMessage: {
      type: String,
      default: "",
    },
    inputId: {
      type: String,
      default: "",
    },
  },
  emits: ["update:modelValue"],
};
</script>

<style lang="scss">
.base-input-group {
  width: 100%;
  @include d-flex($direction: column);

  &__label {
    margin-bottom: 8px;
    color: $gray-color;
    font-size: 14px;

    &.error {
      color: red;
    }
  }

  &__input {
    width: 100%;
    padding: 13px 16px;
    color: black;
    font-size: 16px;
    border: 1px solid $light-gray-color;
    border-radius: 6px;

    &::placeholder {
      color: $gray-color;
    }

    &.error {
      border-color: red;
    }
  }

  &__error {
    margin-top: 5px;
    color: red;
  }
}
</style>
