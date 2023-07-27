<template>
  <base-popup-right
    :is-visible="isVisible"
    :title="cartItems.length ? 'Ваш заказ' : 'Корзина пуста'"
    class="cart-popup"
    @close="$emit('update:isVisible', false)"
  >
    <template #main>
      <cart-popup-item
        v-for="cartItem in cartItems"
        :key="cartItem.item.id"
        :cart-item="cartItem"
      ></cart-popup-item>
    </template>
    <template v-if="cartItems.length" #footer>
      <span class="cart-popup__total-price">
        Итого: {{ cartTotalPrice.toLocaleString("ru") }} ₽
      </span>
      <router-link to="/payment" @click="$emit('update:isVisible', false)">
        <base-button class="cart-popup__checkout-btn">
          Оформить заказ
        </base-button>
      </router-link>
    </template>
  </base-popup-right>
</template>

<script setup>
import BasePopupRight from "@/components/UI/BasePopup/BasePopupRight.vue";
import CartPopupItem from "./CartPopupItem.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import { useCartStore } from "@/stores/cartStore";
import { toRefs } from "vue";

defineProps({
  isVisible: {
    type: Boolean,
    default: false,
  },
});

defineEmits(["update:isVisible"]);

const { cartItems, cartTotalPrice } = toRefs(useCartStore());
</script>

<style lang="scss">
.cart-popup {
  width: 420px;

  &__total-price {
    color: $primary-color;
    font-weight: 600;
    font-size: 20px;

    @include respond-to(sm) {
      font-size: 16px;
    }
  }

  &__checkout-btn {
    padding: 0 24px;
  }
}
</style>
