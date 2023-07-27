<template>
  <form class="authorization-popup-login" @submit.prevent="login">
    <h1 class="authorization-popup-login__title">Вход в аккаунт</h1>
    <p class="authorization-popup-login__message">
      Сможете быстро оформлять заказы, использовать бонусы
    </p>
    <base-input-group
      class="authorization-popup-login__phone-input"
      input-id="phone"
      label="Номер телефона"
      :error-message="v$.phone.$errors[0]?.$message"
    >
      <base-input
        id="phone"
        v-model="state.phone"
        v-maska
        :data-maska="phoneMask"
        type="tel"
        placeholder="+7"
        :is-error="!!v$.phone.$errors[0]"
      ></base-input>
    </base-input-group>
    <base-button class="authorization-popup-login-btn" type="submit">
      Войти
    </base-button>
    <p class="authorization-popup-login__policy">
      Продолжая, вы соглашаетесь со сбором и обработкой персональных данных и
      пользовательским соглашением
    </p>
  </form>
</template>

<script setup>
import BaseInputGroup from "@/components/UI/BaseInputGroup.vue";
import BaseInput from "@/components/UI/BaseInput.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import { reactive } from "vue";
import { vMaska } from "maska";
import { helpers, minLength, required } from "@vuelidate/validators";
import { useVuelidate } from "@vuelidate/core";
import { phoneMask } from "@/staticData/constants.js";

const state = reactive({
  phone: "",
});

const rules = {
  phone: {
    required: helpers.withMessage("Введите номер", required),
    minLength: helpers.withMessage("Введите номер", minLength(18)),
  },
};

const v$ = useVuelidate(rules, state);

const emit = defineEmits(["phoneEntered"]);
const login = async () => {
  if (await v$.value.$validate()) {
    emit("phoneEntered", state.phone);
  }
};
</script>

<style lang="scss">
.authorization-popup-login {
  width: 100%;
  max-width: 320px;
  margin: auto;
  @include d-flex(center, center, column);

  &__title {
    margin-bottom: 16px;
    font-weight: 600;
    font-size: 32px;
  }

  &__message {
    margin-bottom: 20px;
    line-height: 22px;
    text-align: center;
  }

  &__phone-input {
    margin-bottom: 16px;
  }

  &-btn {
    width: 100%;
    margin-bottom: 12px;
  }

  &__policy {
    font-size: 14px;
    line-height: 18px;
    text-align: center;
    opacity: 0.4;
  }
}
</style>
