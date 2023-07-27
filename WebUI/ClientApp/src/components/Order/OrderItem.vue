<template>
  <div class="order-item">
    <div
      class="order-item__top"
      @click="isProductsVisible = !isProductsVisible"
    >
      <div class="order-item__top-columns">
        <div class="order-item__top-column">
          <span class="order-item__top-column-title">Заказ</span>
          <p class="order-item__top-column-content">№{{ order.orderId }}</p>
        </div>
        <div class="order-item__top-column">
          <span class="order-item__top-column-title">Дата</span>
          <p class="order-item__top-column-content">
            {{ formattedOrderDate }}
          </p>
        </div>
        <div class="order-item__top-column">
          <span class="order-item__top-column-title"> Сумма заказа </span>
          <p class="order-item__top-column-content">
            {{ orderPrice.toLocaleString("ru") }} ₽
          </p>
        </div>
        <div class="order-item__top-column">
          <span class="order-item__top-column-title">Оплата</span>
          <p class="order-item__top-column-content">
            {{ order.paymentMethodName }}
          </p>
        </div>
      </div>
      <down-arrow-icon
        :width="16"
        :height="9"
        class="order-item__top-arrow"
        :class="{ open: isProductsVisible }"
      ></down-arrow-icon>
    </div>
    <p class="order-item__address">
      ул. {{ order.street }} {{ order.house }}, кв {{ order.apartment }}
    </p>
    <Transition name="order-products-fade">
      <div v-if="isProductsVisible" class="order-item__products">
        <order-product-item
          v-for="(orderProduct, index) in order.products"
          :key="index"
          :order-product="orderProduct"
        >
        </order-product-item>
      </div>
    </Transition>
  </div>
</template>

<script setup>
import { computed, ref } from "vue";
import OrderProductItem from "@/components/Order/OrderProductItem.vue";
import DownArrowIcon from "@/components/UI/Icons/DownArrowIcon.vue";

const props = defineProps({
  order: {
    type: Object,
    required: true,
  },
});

const isProductsVisible = ref(false);

const formattedOrderDate = computed(() => {
  const date = new Date(props.order.date);

  return date.toLocaleDateString("ru", {
    day: "numeric",
    month: "numeric",
    year: "2-digit",
  });
});

const orderPrice = computed(() =>
  props.order.products.reduce(
    (acc, item) => acc + item.quantity * item.price,
    0
  )
);
</script>

<style lang="scss">
.order-item {
  margin-bottom: 20px;
  padding: 16px 20px;
  background-color: white;
  border-radius: $primary-border-radius;

  &__top {
    margin-bottom: 22px;
    padding-bottom: 16px;
    border-bottom: 1px solid $light-gray-color;
    cursor: pointer;

    @include d-flex($align-items: center);

    &-columns {
      display: grid;
      grid-auto-flow: column;
      grid-template-columns: repeat(4, 1fr);
      width: 100%;

      @include respond-to(sm) {
        grid-template-rows: repeat(2, 1fr);
        grid-template-columns: repeat(2, 1fr);
      }
    }

    &-column {
      @include d-flex($direction: column);
      @include respond-to(sm) {
        margin-bottom: 6px;
      }

      &-title {
        margin-bottom: 4px;
        color: $gray-color;
        font-size: 14px;
      }
    }

    &-arrow {
      margin-left: auto;
      color: $primary-color;
      transition: transform 0.2s;

      &.open {
        transform: rotate(180deg);
      }
    }
  }

  &__products {
    margin-top: 20px;
    padding-top: 12px;
    border-top: 1px solid $light-gray-color;
  }
}

.order-products-fade-enter-active,
.order-products-fade-leave-active {
  transition: opacity 0.1s ease-in-out;
}

.order-products-fade-enter-from,
.order-products-fade-leave-to {
  opacity: 0;
}
</style>
