<template>
  <div class="account-history">
    <base-loader :is-loading="isLoading"></base-loader>

    <p v-if="!isLoading && orders.length === 0">У вас нет заказов</p>
    <div v-else class="account-history__orders">
      <order-item
        v-for="order in orders"
        :key="order.orderId"
        :order="order"
      ></order-item>
    </div>

    <base-pagination
      v-if="totalPages > 0"
      v-model:current-page="currentPage"
      :total-pages="totalPages"
      :available-pages-count="2"
      class="account-history__pagination"
      @page-change="onPageChange"
    ></base-pagination>
  </div>
</template>

<script setup>
import { getUserOrders } from "@/api/orders";
import { onMounted, ref } from "vue";
import BasePagination from "@/components/UI/BasePagination.vue";
import BaseLoader from "@/components/UI/BaseLoader.vue";
import OrderItem from "@/components/Order/OrderItem.vue";

const orders = ref([]);
const isLoading = ref(true);

const currentPage = ref(1);
const totalPages = ref(0);

onMounted(async () => {
  const response = await getUserOrders(currentPage.value);
  isLoading.value = false;

  totalPages.value = response.totalPages;
  orders.value = response.items;
});
const onPageChange = async (newPage) => {
  orders.value = null;
  const response = await getUserOrders(newPage);
  totalPages.value = response.totalPages;

  orders.value = response.items;
};
</script>

<style lang="scss">
.account-history {
  min-height: 630px;
  margin-bottom: 60px;
  @include d-flex($direction: column);

  &__pagination {
    align-self: center;
    margin-top: auto;
  }
}
</style>
