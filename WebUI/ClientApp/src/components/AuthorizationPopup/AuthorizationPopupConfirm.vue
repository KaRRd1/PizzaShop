<template>
  <form class="authorization-popup-confirm" @submit.prevent="login">
    <h1 class="authorization-popup-confirm__title">Код из смс</h1>
    <p class="authorization-popup-confirm__info">
      На номер {{ phone }} <br />
      (Введите любой код)
    </p>
    <authorization-popup-confirm-code
      :code="code"
    ></authorization-popup-confirm-code>
    <p v-if="isError" class="authorization-popup-confirm__error">Введите код</p>
    <base-button class="authorization-popup-confirm__login" type="submit">
      Войти
    </base-button>
    <base-transparent-button
      class="authorization-popup-confirm__reset"
      type="button"
      @click="resetPhone"
    >
      Указать другой номер
    </base-transparent-button>
  </form>
</template>

<script setup>
import AuthorizationPopupConfirmCode from "@/components/AuthorizationPopup/AuthorizationPopupConfirmCode.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import BaseTransparentButton from "@/components/UI/BaseTransparentButton.vue";
import { computed, ref } from "vue";
import { useAuthStore } from "@/stores/authStore";

const props = defineProps({
  phone: {
    type: String,
    required: true,
  },
});

const emit = defineEmits(["update:phone", "successLogin"]);

const code = ref(["", "", "", ""]);
const isError = ref(false);
const resetPhone = () => emit("update:phone", "");
const codeIsValid = computed(() => code.value.every((x) => x));

const authStore = useAuthStore();
const login = async () => {
  if (codeIsValid.value) {
    isError.value = false;

    if (await authStore.login(props.phone)) {
      emit("successLogin");
    }
  } else {
    isError.value = true;
  }
};
</script>

<style lang="scss">
.authorization-popup-confirm {
  width: 100%;
  max-width: 240px;
  margin: auto;
  @include d-flex(center, center, column);

  &__title {
    margin-bottom: 16px;
    font-weight: 600;
    font-size: 32px;
  }

  &__info {
    margin-bottom: 20px;
    text-align: center;
  }

  &__form {
    width: 100%;
  }

  &__login {
    width: 100%;
    margin-bottom: 16px;
  }

  &__reset {
    color: $primary-color;
  }

  &__error {
    margin-bottom: 12px;
    color: red;
    font-size: 14px;
  }
}
</style>
