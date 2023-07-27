<template>
  <div class="base-tabs">
    <button
      v-for="(tab, index) in tabs"
      :key="index"
      class="base-tabs__item"
      :class="{
        selected: tab[tabValueProperty] === selectedTab[tabValueProperty],
      }"
      @click="selectionChange(tab)"
    >
      {{ tab.name }}
    </button>
  </div>
</template>

<script setup>
defineProps({
  tabs: {
    type: Array,
    required: true,
  },
  selectedTab: {
    type: Object,
    required: true,
  },
  tabValueProperty: {
    type: String,
    default: "value",
  },
});

const emit = defineEmits(["selectionChange", "update:selectedTab"]);
const selectionChange = (tab) => {
  emit("update:selectedTab", tab);
  emit("selectionChange", tab);
};
</script>

<style lang="scss">
.base-tabs {
  width: 100%;
  height: 48px;
  border: 1px solid $light-gray-color;
  border-radius: 6px;

  @include d-flex(center);

  &__item {
    flex: 1;
    font-size: inherit;
    background-color: white;
    border-radius: 6px;

    &.selected {
      color: white;
      background-color: $primary-color;
    }
  }
}
</style>
