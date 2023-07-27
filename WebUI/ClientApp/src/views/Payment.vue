<template>
  <div class="payment">
    <payment-success
      v-if="createdOrderId"
      :order-id="createdOrderId"
    ></payment-success>
    <template v-else>
      <h1 class="payment__title">Ваш заказ</h1>
      <template v-if="cartStore.cartItems.length">
        <div class="payment__cart-items">
          <cart-popup-item
            v-for="(cartItem, index) in cartStore.cartItems"
            :key="index"
            :cart-item="cartItem"
            :index="index"
            :is-inline="true"
          ></cart-popup-item>
        </div>
        <form ref="form" class="payment__form" @submit.prevent="createOrder">
          <section class="payment__section">
            <h3 class="payment__section-title">О вас</h3>
            <div class="payment__row-inline">
              <base-input-group
                label="Имя*"
                class="payment__input-group"
                input-id="name"
                :error-message="v$.name.$errors[0]?.$message"
              >
                <base-input
                  id="name"
                  v-model="order.name"
                  placeholder="Алексей"
                  :is-error="!!v$.name.$errors.length"
                ></base-input>
              </base-input-group>
              <base-input-group
                label="Номер телефона*"
                class="payment__input-group"
                input-id="phone"
                :error-message="v$.phone.$errors[0]?.$message"
              >
                <base-input
                  id="phone"
                  v-model="order.phone"
                  v-maska
                  placeholder="+7"
                  :is-error="!!v$.phone.$errors.length"
                  :data-maska="phoneMask"
                ></base-input>
              </base-input-group>
              <base-input-group
                label="Почта"
                class="payment__input-group"
                input-id="email"
                :error-message="v$.email.$errors[0]?.$message"
              >
                <base-input
                  id="email"
                  v-model="order.email"
                  placeholder="mail@gmail.com"
                  :is-error="!!v$.email.$errors.length"
                  :empty-as-null="true"
                ></base-input>
              </base-input-group>
            </div>
          </section>
          <section class="payment__section">
            <h3 class="payment__section-title">Доставка</h3>
            <base-input-group
              label="Улица*"
              class="payment__row payment__input-group"
              input-id="street"
              :error-message="v$.street.$errors[0]?.$message"
            >
              <base-input
                id="street"
                v-model="order.street"
                placeholder="Пушкина"
                :is-error="!!v$.street.$errors.length"
              >
              </base-input>
            </base-input-group>
            <div class="payment__row-inline">
              <base-input-group
                label="Дом*"
                class="payment__input-group"
                input-id="house"
                :error-message="v$.house.$errors[0]?.$message"
              >
                <base-input
                  id="house"
                  v-model="order.house"
                  placeholder="1a"
                  :is-error="!!v$.house.$errors.length"
                ></base-input>
              </base-input-group>
              <base-input-group
                label="Подъезд"
                class="payment__input-group"
                input-id="entrance"
              >
                <base-input
                  id="entrance"
                  v-model="order.entrance"
                  v-maska
                  data-maska="###"
                  placeholder="1"
                  :empty-as-null="true"
                ></base-input>
              </base-input-group>
              <base-input-group
                label="Этаж"
                class="payment__input-group"
                input-id="floor"
              >
                <base-input
                  id="floor"
                  v-model="order.floor"
                  v-maska
                  data-maska="##"
                  placeholder="2"
                  :empty-as-null="true"
                ></base-input>
              </base-input-group>
              <base-input-group
                label="Квартира"
                class="payment__input-group"
                input-id="apartment"
              >
                <base-input
                  id="apartment"
                  v-model="order.apartment"
                  v-maska
                  placeholder="3"
                  data-maska="####"
                  :empty-as-null="true"
                ></base-input>
              </base-input-group>
            </div>
          </section>
          <section class="payment__section">
            <h3 class="payment__section-title">Оплата</h3>
            <div class="payment__row-radio-buttons">
              <base-radio-button
                v-model="order.paymentMethodId"
                class="payment__radio-btn"
                label="Наличными"
                name="cash"
                :value="1"
              ></base-radio-button>
              <base-radio-button
                v-model="order.paymentMethodId"
                class="payment__radio-btn"
                label="Картой онлайн"
                name="card"
                :value="2"
              ></base-radio-button>
            </div>
          </section>
          <section class="payment__section">
            <h3 class="payment__section-title">Комментарий</h3>
            <base-input
              v-model="order.comment"
              placeholder="Есть уточнения?"
              class="payment__comment-textarea"
              :is-textarea="true"
              :is-error="!!v$.comment.$errors.length"
              :empty-as-null="true"
            ></base-input>
          </section>
          <div class="payment__footer">
            <div class="payment__checkout">
              <span class="payment__total-price">
                Итого: {{ cartStore.cartTotalPrice.toLocaleString("ru") }} ₽
              </span>
              <base-button class="payment__checkout-btn">
                Оформить заказ
              </base-button>
            </div>
            <p v-if="!isLoggedIn" class="payment__note">
              Авторизируйтесь, чтобы ваш заказ отобразился в профиле.
            </p>
          </div>
        </form>
      </template>
      <p v-else>Вы пока ничего не выбрали.</p>
    </template>
  </div>
</template>

<script setup>
import { useVuelidate } from "@vuelidate/core";
import {
  required,
  helpers,
  minLength,
  email,
  maxLength,
} from "@vuelidate/validators";
import { vMaska } from "maska";
import { useCartStore } from "@/stores/cartStore";
import BaseInput from "@/components/UI/BaseInput.vue";
import CartPopupItem from "@/components/CartPopup/CartPopupItem.vue";
import BaseInputGroup from "@/components/UI/BaseInputGroup.vue";
import BaseRadioButton from "@/components/UI/BaseRadioButton.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import { createOrder as createOrderApi } from "@/api/orders";
import { reactive, ref, toRef } from "vue";
import { useAuthStore } from "@/stores/authStore";
import PaymentSuccess from "@/components/PaymentSuccess.vue";
import { phoneMask } from "@/staticData/constants.js";

const cartStore = useCartStore();
const authStore = useAuthStore();

const { user } = authStore;
const isLoggedIn = toRef(authStore, "isLoggedIn");

const order = reactive({
  name: user?.name ?? "",
  phone: user?.phone ?? "",
  email: user?.email ?? null,
  street: "",
  house: "",
  entrance: null,
  floor: null,
  apartment: null,
  paymentMethodId: 1,
  comment: null,
});

const maxLengthRule = (length) =>
  helpers.withMessage(
    ({ $params }) => `Макс. длина ${$params.max} символов`,
    maxLength(length)
  );

const rules = {
  name: {
    required: helpers.withMessage("Укажите Ваше имя", required),
    maxLength: maxLengthRule(18),
  },
  phone: {
    required: helpers.withMessage("Введите номер телефона", required),
    minLength: helpers.withMessage("Введите номер телефона", minLength(18)),
  },
  email: {
    email: helpers.withMessage("Неверный формат почты", email),
    maxLength: maxLengthRule(40),
  },
  street: {
    required: helpers.withMessage("Введите улицу", required),
    maxLength: maxLengthRule(100),
  },
  house: {
    required: helpers.withMessage("Введите дом", required),
    maxLength: maxLengthRule(10),
  },
  comment: {
    maxLength: helpers.withMessage(
      ({ $params }) => `Макс. длина ${$params.max} символов`,
      maxLength(200)
    ),
  },
};

const v$ = useVuelidate(rules, order);

const createdOrderId = ref(0);
const createOrder = async () => {
  if (await v$.value.$validate()) {
    const productVariations = cartStore.cartItems.map(({ quantity, item }) => ({
      productVariationId: item.id,
      quantity,
    }));

    const createdOrder = await createOrderApi({ ...order, productVariations });
    createdOrderId.value = createdOrder.orderId;

    cartStore.clearCart();
    window.scrollTo(0, 0);
  }
};
</script>

<style lang="scss">
.payment {
  max-width: 850px;
  margin: auto;
  padding-bottom: 50px;
  @include respond-to(sm) {
    max-width: 480px;
  }

  &__title {
    margin-bottom: 24px;
  }

  &__section {
    margin-bottom: 20px;
    padding-bottom: 20px;
    border-bottom: 1px solid $light-gray-color;

    &-title {
      margin-bottom: 16px;
    }
  }

  &__row-inline {
    @include d-flex(space-between);
    @include respond-to(sm) {
      flex-wrap: wrap;
    }
  }

  &__row {
    margin-bottom: 16px;
  }

  &__row-radio-buttons {
    display: flex;
  }

  &__radio-btn {
    margin-left: 24px;

    &:first-child {
      margin-left: 0;
    }
  }

  &__input-group {
    margin-right: 12px;
    @include respond-to(sm) {
      margin-right: 0;
      margin-bottom: 12px;
    }

    &:last-child {
      margin-right: 0;
    }
  }

  &__checkout {
    margin-bottom: 6px;
    @include d-flex(space-between, center);

    &-btn {
      padding: 0 24px;
    }
  }

  &__note {
    color: $gray-color;
    font-size: 14px;
    text-align: right;
  }

  &__total-price {
    color: $primary-color;
    font-weight: 600;
    font-size: 20px;
    @include respond-to(sm) {
      font-size: 16px;
    }
  }

  &__comment-textarea {
    height: 200px;
  }
}
</style>
