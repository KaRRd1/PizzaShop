<template>
  <div class="base-radio-button">
    <input type="radio" :name="name" :value="value" :checked="isChecked" />
    <label
      :for="name"
      class="base-radio-button__label"
      @click="$emit('update:modelValue', value)"
      >{{ label }}</label
    >
  </div>
</template>

<script>
export default {
  name: "BaseRadioButton",
  props: {
    modelValue: {
      type: [String, Number],
      required: false,
      default: "",
    },
    name: {
      type: String,
      required: true,
    },
    label: {
      type: String,
      required: true,
    },
    value: {
      type: [String, Number],
      default: 0,
    },
  },
  emits: ["update:modelValue"],
  computed: {
    isChecked() {
      return this.modelValue === this.value;
    },
  },
};
</script>

<style lang="scss">
.base-radio-button {
  &__label {
    cursor: pointer;
    transition: 0.2s ease-in-out;

    @include d-flex($align-items: center);

    &:before {
      display: inline-block;
      width: 16px;
      height: 16px;
      margin-right: 8px;
      background-color: white;
      border: 1px solid $gray-color;
      border-radius: 100%;
      transition: all 250ms ease;
      content: "";
    }

    &:hover {
      color: $primary-color;
    }
  }

  input[type="radio"] {
    position: absolute;
    width: 0;
    height: 0;
    opacity: 0;

    &:checked {
      + .base-radio-button__label {
        &:before {
          background-color: $primary-color;
          border-color: $primary-color;
          box-shadow: inset 0 0 0 3px white;
        }
      }
    }
  }
}
</style>
