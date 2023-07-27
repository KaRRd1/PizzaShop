<template>
  <div v-click-outside="() => (isActive = false)" class="dropdown-menu">
    <div class="dropdown-menu__header" @click="toggleActive">
      <div class="dropdown-menu__title">
        <slot name="title"></slot>
      </div>
      <down-arrow-icon
        v-show="arrowIsVisible"
        :width="16"
        :height="9"
      ></down-arrow-icon>
    </div>
    <div
      v-show="isActive"
      class="dropdown-menu__items"
      :class="menuPosition"
      @click="toggleActive"
    >
      <slot name="menu"></slot>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import DownArrowIcon from "@/components/UI/Icons/DownArrowIcon.vue";
import vClickOutside from "@/directives/ClickOutside";

defineProps({
  menuPosition: {
    type: String,
    default: "center",
    validator(value) {
      return ["left", "center", "right"].includes(value);
    },
  },
  arrowIsVisible: {
    type: Boolean,
    default: true,
  },
});

const isActive = ref(false);
const toggleActive = () => (isActive.value = !isActive.value);
</script>

<style lang="scss">
.dropdown-menu {
  position: relative;
  user-select: none;

  &__header {
    cursor: pointer;
    @include d-flex($align-items: center);
  }

  &__title {
    margin-right: 8px;
  }

  &__items {
    position: absolute;
    top: calc(100% + 15px);
    z-index: 1;
    width: max-content;
    padding: 20px;
    background-color: white;
    border: 1px solid #f0f0f0;
    border-radius: $primary-border-radius;
    box-shadow: 0 2px 8px rgba(25, 25, 25, 0.1);
    cursor: default;

    @include d-flex($direction: column);

    &.center {
      left: 50%;
      transform: translate(-50%, 0);
    }

    &.left {
      right: 0;
    }

    &.right {
      left: 0;
    }
  }
}
</style>
