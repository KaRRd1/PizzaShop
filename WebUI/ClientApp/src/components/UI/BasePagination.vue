<template>
  <div class="base-pagination">
    <base-button
      class="base-pagination__btn"
      :disabled="currentPage <= 1"
      @click="changePage(currentPage - 1)"
    >
      <left-arrow-icon :width="10" :height="18"></left-arrow-icon>
    </base-button>

    <base-transparent-button
      v-for="page in availablePages"
      :key="page"
      class="base-pagination__btn base-pagination__page-btn"
      :class="{ active: currentPage === page }"
      :disabled="currentPage === page"
      @click="changePage(page)"
    >
      {{ page }}
    </base-transparent-button>

    <base-button
      class="base-pagination__btn"
      :disabled="currentPage >= totalPages"
      @click="changePage(currentPage + 1)"
    >
      <right-arrow-icon :width="10" :height="18"></right-arrow-icon>
    </base-button>
  </div>
</template>

<script setup>
import { computed } from "vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import LeftArrowIcon from "@/components/UI/Icons/LeftArrowIcon.vue";
import RightArrowIcon from "@/components/UI/Icons/RightArrowIcon.vue";
import BaseTransparentButton from "@/components/UI/BaseTransparentButton.vue";

const props = defineProps({
  currentPage: {
    type: Number,
    required: true,
  },
  totalPages: {
    type: Number,
    required: true,
  },
  availablePagesCount: {
    type: Number,
    default: 4,
  },
  pageInUrl: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(["pageChange", "update:currentPage"]);

const availablePages = computed(() => {
  const pages = [];
  const offset = props.availablePagesCount / 2;
  const { currentPage, totalPages } = props;

  if (totalPages <= 0) return;
  if (currentPage < 1) emit("update:currentPage", 1);
  if (currentPage > totalPages) emit("update:currentPage", totalPages);

  for (let i = -offset; i < 0; i++) {
    if (currentPage + i >= 1) pages.push(currentPage + i);
  }

  const prevPagesCount = pages.length;
  for (let i = 0; i < offset + (offset - prevPagesCount); i++) {
    if (currentPage + i <= totalPages) pages.push(currentPage + i);
  }

  if (pages.at(-1) < totalPages) pages.push(totalPages);

  return pages;
});

const changePage = async (newPage) => {
  emit("pageChange", newPage);
  emit("update:currentPage", newPage);
};
</script>

<style lang="scss">
.base-pagination {
  @include d-flex();

  &__btn {
    width: 48px;
    height: 48px;
    margin-right: 16px;

    @include respond-to(sm) {
      width: 44px;
      height: 44px;
      margin-right: 8px;
    }

    &:last-child {
      margin-right: 0;
    }
  }

  &__page-btn {
    background-color: white;
    border: 1px solid $light-gray-color;
    border-radius: 6px;

    &.active {
      color: $primary-color;
      font-weight: 600;
    }
  }
}
</style>
