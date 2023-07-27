<template>
  <div class="order-product-item">
    <img
      class="order-product-item__img"
      :src="orderProduct.imageSmallUrl"
      alt="product"
    />
    <div class="order-product-item__content">
      <span class="order-product-item__title">
        {{ orderProduct.productName }}
      </span>
      <p class="order-product-item__description">{{ getDescription() }}</p>
      <div class="order-product-item__info">
        <div class="order-product-item__quantity">
          {{ orderProduct.quantity }} шт.
        </div>
        <span class="order-product-item__price">
          {{ orderProduct.price }} ₽
        </span>
      </div>
    </div>
  </div>
</template>

<script setup>
const props = defineProps({
  orderProduct: {
    type: Object,
    required: true,
  },
});

const getDescription = () => {
  const { orderProduct } = props;

  const parameters = [
    orderProduct.type?.name,
    `${orderProduct.size.value} ${orderProduct.size.unitName}`,
  ];

  return parameters.filter((x) => x).join(", ");
};
</script>

<style lang="scss">
.order-product-item {
  margin-bottom: 12px;
  @include d-flex($align-items: center);

  &:last-child {
    margin-bottom: 0;
  }

  &__img {
    width: 40px;
    height: 40px;
    margin-right: 16px;

    @include respond-to(sm) {
      width: 76px;
      height: 76px;
      margin-right: 8px;
    }
  }

  &__content {
    width: 100%;
    @include d-flex($align-items: center);
    @include respond-to(sm) {
      flex-direction: column;
      align-items: flex-start;
    }
  }

  &__title {
    margin-right: 36px;
    font-weight: 600;

    @include respond-to(sm) {
      margin-bottom: 4px;
    }
  }

  &__description {
    font-size: 14px;

    @include respond-to(sm) {
      margin-bottom: 6px;
    }
  }

  &__info {
    margin-left: auto;
    @include d-flex($align-items: center);
    @include respond-to(sm) {
      justify-content: space-between;
      width: 100%;
      margin-left: 0;
    }
  }

  &__quantity {
    width: 80px;
    padding: 6px 0;
    color: $primary-color;
    font-weight: 600;
    text-align: center;
    background-color: #ffeee2;
    border-radius: 6px;
  }

  &__price {
    margin-left: 25px;
    color: $primary-color;
    font-weight: 600;
    @include respond-to(sm) {
      margin-left: 0;
    }
  }
}
</style>
