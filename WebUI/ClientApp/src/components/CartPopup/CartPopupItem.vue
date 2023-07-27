<template>
  <div class="cart-item">
    <img
      :src="cartItem.item.image"
      class="cart-item__img"
      :class="{ inline: isInline }"
      alt=""
    />
    <div class="cart-item__right" :class="{ inline: isInline }">
      <div class="cart-item__content">
        <h5 class="cart-item__title">{{ cartItem.item.name }}</h5>
        <p class="cart-item__description">{{ description }}</p>
      </div>
      <div class="cart-item__footer" :class="{ inline: isInline }">
        <div class="cart-item__counter">
          <button
            class="cart-item__counter-btn"
            @click="cartStore.decrementQuantity(cartItem.item.id)"
          >
            -
          </button>
          <span>{{ cartItem.quantity }}</span>
          <button
            class="cart-item__counter-btn"
            @click="cartStore.incrementQuantity(cartItem.item.id)"
          >
            +
          </button>
        </div>
        <span class="cart-item__price">{{ cartItem.item.price }} ₽</span>
      </div>
    </div>
  </div>
</template>

<script setup>
import { useCartStore } from "@/stores/cartStore";
import { computed } from "vue";

const props = defineProps({
  cartItem: {
    type: Object,
    required: true,
  },
  isInline: {
    type: Boolean,
    default: false,
  },
});

const cartStore = useCartStore();

const description = computed(() => {
  const { item } = props.cartItem;

  const parameters = [
    item.type?.name,
    `${item.size.value} ${item.size.unitName}`,
  ];

  return parameters.filter((x) => x).join(", ");
});
</script>

<style lang="scss">
.cart-item {
  display: flex;
  margin-bottom: 20px;
  padding: 16px;
  background-color: white;
  border: 1px solid #f0f0f0;
  border-radius: 12px;

  &__img {
    width: 94px;
    height: 94px;
    margin-right: 16px;

    &.inline {
      width: 120px;
      height: 120px;

      @include respond-to(sm) {
        width: 84px;
        height: 84px;
      }
    }
  }

  &__content {
    width: 100%;
  }

  &__right {
    width: 100%;
    max-width: 250px;
    @include d-flex(space-between, $direction: column);

    &.inline {
      max-width: none;
      @include d-flex($align-items: center, $direction: row);
      @include respond-to(sm) {
        flex-direction: column;
        align-items: flex-start;
      }
    }
  }

  &__title {
    margin-bottom: 8px;
    font-weight: 600;
    font-size: 16px;
    @include respond-to(sm) {
      font-size: 14px;
    }
  }

  &__description {
    margin-bottom: 6px;

    @include respond-to(sm) {
      font-size: 12px;
    }
  }

  &__footer {
    @include d-flex(space-between, center);

    &.inline {
      width: 100%;
      max-width: 170px;
    }
  }

  &__counter {
    width: 100%;
    max-width: 92px;
    height: 36px;
    margin-right: 6px;
    color: $primary-color;
    font-weight: 600;
    background-color: #ffeee2;
    border-radius: 6px;
    @include d-flex(space-between, center);

    &-btn {
      width: 28px;
      height: 100%;
      color: $primary-color;
      font-weight: 600;
      font-size: 18px;
      background-color: transparent;
      border: 1px solid transparent;
      border-radius: inherit;

      &:hover {
        border-color: $primary-color;
      }
    }
  }

  &__price {
    margin-left: auto;
    color: $primary-color;
    font-weight: 600;
  }
}
</style>
