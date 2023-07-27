<template>
  <div class="payment-success">
    <img
      class="payment-success__img"
      src="@/assets/svg/payment-order.svg"
      alt=""
    />
    <h3 class="payment-success__title">Заказ №{{ orderId }} принят</h3>
    <p class="payment-success__message">
      Спасибо за заказ!<br />
      Примерное время доставки 45 минут.
    </p>
  </div>
</template>

<script setup>
defineProps({
  orderId: {
    type: Number,
    required: true,
  },
});
</script>

<style lang="scss">
.payment-success {
  margin-top: 100px;
  @include d-flex(center, center, column);

  &__img {
    margin-bottom: 48px;
  }

  &__title {
    margin-bottom: 16px;
    font-weight: 600;
    font-size: 24px;
  }

  &__message {
    max-width: 380px;
    line-height: 1.37;
    text-align: center;
  }
}
</style>
