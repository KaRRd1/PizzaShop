<template>
  <base-popup-center class="authorization-popup" :is-visible="isVisible" @close="$emit('update:isVisible', false)">
    <authorization-popup-login
      v-if="!phone"
      @phone-entered="onPhoneEntered"
    ></authorization-popup-login>

    <authorization-popup-confirm
      v-else
      v-model:phone="phone"
      @success-login="$emit('update:isVisible', false)"
    ></authorization-popup-confirm>
  </base-popup-center>
</template>

<script setup>
import BasePopupCenter from "@/components/UI/BasePopup/BasePopupCenter.vue";
import AuthorizationPopupLogin from "@/components/AuthorizationPopup/AuthorizationPopupLogin.vue";
import AuthorizationPopupConfirm from "@/components/AuthorizationPopup/AuthorizationPopupConfirm.vue";
import { ref, watch } from "vue";

const props = defineProps({
  isVisible: {
    type: Boolean,
    default: false,
  },
});

defineEmits(["update:isVisible"]);

const phone = ref("");

watch(
  () => props.isVisible,
  () => (phone.value = "")
);

const onPhoneEntered = (value) => {
  phone.value = value;
};
</script>

<style lang="scss">
.authorization-popup {
  width: 100%;
  max-width: 850px;
  padding: 60px 0;
}
</style>
