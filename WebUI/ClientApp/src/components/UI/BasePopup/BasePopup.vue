<template>
  <teleport to="body">
    <transition name="popup-transition">
      <div v-if="isVisible" class="base-popup-backdrop" @click.self="onClose">
        <div v-bind="$attrs" ref="popup" class="base-popup">
          <div
            class="mobile-swipe-wrapper"
            @click="onClose"
            @touchstart.passive="touchStart"
            @touchmove.passive="touchMove"
            @touchend.passive="touchEnd"
          >
            <span class="mobile-swipe-indicator"></span>
          </div>
          <slot></slot>
        </div>
      </div>
    </transition>
  </teleport>
</template>

<script>
export default {
  inheritAttrs: false,
};
</script>

<script setup>
import { ref, toRef } from "vue";
import { useBodyOverflow } from "@/hooks/useBodyOverflow";

const props = defineProps({
  isVisible: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(["update:isVisible", "close"]);

const onClose = () => {
  emit("update:isVisible", false);
  emit("close");
};

useBodyOverflow(toRef(props, "isVisible"), "popup_is-open");

const popup = ref(null);
const startTouchY = ref(null);

const touchStart = (touchEvent) => {
  if (!props.isVisible) return;
  
  startTouchY.value = touchEvent.targetTouches[0].clientY;
}
const touchMove = (touchEvent) => {
  if (!props.isVisible) return;
  
  const currentTouchY = touchEvent.targetTouches[0].clientY;

  if (currentTouchY > startTouchY.value) {
    popup.value.style.bottom = -(currentTouchY - startTouchY.value) + "px";
  }
};
const touchEnd = () => {
  if (!props.isVisible) return;
  
  const popupHeight = popup.value.clientHeight;
  const hiddenHeight = Math.abs(parseInt(popup.value.style.bottom));

  if (hiddenHeight > popupHeight / 2) {
    onClose();
  } else {
    popup.value.style.bottom = "";
  }
};
</script>

<style lang="scss">
.base-popup {
  position: fixed;

  @include respond-to(sm) {
    bottom: 0;
    width: 100% !important;
    height: 90% !important;
    border-radius: $primary-border-radius $primary-border-radius 0 0 !important;
  }

  &-backdrop {
    position: fixed;
    top: 0;
    left: 0;
    z-index: 11;
    width: 100%;
    height: 100%;
    background: rgba(25, 25, 25, 0.4);
    backdrop-filter: blur(16px);
  }
}

.popup_is-open {
  overflow: hidden;
}

.popup-transition-enter-active,
.popup-transition-leave-active {
  transition: opacity 0.3s;
}

.popup-transition-enter-from,
.popup-transition-leave-to {
  opacity: 0;
}

.mobile-swipe {
  &-wrapper {
    position: absolute;
    bottom: 100%;
    left: 0;
    display: none;
    width: 100%;
    height: 100%;

    @include respond-to(sm) {
      display: block;
    }
  }

  &-indicator {
    position: absolute;
    right: 50%;
    bottom: 12px;
    left: 50%;
    width: 135px;
    height: 5px;
    background-color: $light-gray-color;
    border-radius: 16px;
    transform: translate(-50%, -50%);
  }
}
</style>
