<template>
  <div class="account">
    <div class="account__header">
      <h1 class="account__header-title">Мой аккаунт</h1>
      <h1 class="account__header-mobile-title">{{ selectedTab.name }}</h1>
      <base-tabs
        v-model:selected-tab="selectedTab"
        class="account__tabs"
        :tabs="tabs"
        @selection-change="onSelectionChange"
      >
      </base-tabs>
    </div>

    <router-view v-slot="{ Component }">
      <keep-alive include="AccountHistory">
        <Component :is="Component"></Component>
      </keep-alive>
    </router-view>
  </div>
</template>

<script setup>
import { ref, watch } from "vue";
import { useRoute, useRouter } from "vue-router";
import BaseTabs from "@/components/UI/BaseTabs.vue";

const tabs = [
  {
    name: "История",
    value: "accountHistory",
  },
  {
    name: "Настройки",
    value: "accountSettings",
  },
];

const selectedTab = ref({});
const route = useRoute();

watch(
  () => route,
  () => {
    const tabFromPath = tabs.find((tab) => tab.value === route.name);
    selectedTab.value = tabFromPath ? tabFromPath : tabs[0];
  },
  { immediate: true, deep: true }
);

const router = useRouter();
const onSelectionChange = (tab) => {
  router.replace({ name: tab.value });
};
</script>

<style lang="scss">
.account {
  max-width: 850px;
  margin: auto;
  @include respond-to(sm) {
    max-width: 480px;
  }

  &__header {
    margin-bottom: 24px;

    @include d-flex(space-between, center);

    &-title {
      @include respond-to(sm) {
        display: none;
      }
    }

    &-mobile-title {
      display: none;

      @include respond-to(sm) {
        display: block;
      }
    }
  }

  &__tabs {
    width: 360px;

    @include respond-to(sm) {
      display: none;
    }
  }
}
</style>
