<template>
  <BasePopupCenter :is-visible="isVisible" class="choose-product-popup" @close="$emit('update:isVisible', false)">
    <template v-if="product">
      <div class="choose-product-popup__main">
        <img
          class="choose-product-popup__img"
          :src="product.imageLargeUrl"
          alt=""
        />
        <div class="choose-product-popup__content">
          <h4 class="choose-product-popup__title">{{ product.name }}</h4>
          <p class="choose-product-popup__description">
            {{ product.description }}
          </p>
          <BaseTabs
            v-if="currentType"
            v-model:selected-tab="currentType"
            class="choose-product-popup__tabs"
            :tabs="productTypeTabs"
            tab-value-property="id"
          ></BaseTabs>
          <BaseTabs
            v-if="currentSize"
            v-model:selected-tab="currentSize"
            class="choose-product-popup__tabs"
            :tabs="productSizeTabs"
            tab-value-property="id"
          ></BaseTabs>
        </div>
      </div>
      <div class="choose-product-popup__footer">
        <div class="choose-product-popup__footer-left">
          <span class="choose-product-popup__total-price">
            Итого: {{ currentVariation.price }} ₽
          </span>
          <span
            v-if="currentVariation.weightGrams"
            class="choose-product-popup__weight"
          >
            {{ currentVariation.weightGrams }} г
          </span>
        </div>
        <BaseButton class="choose-product-popup__add-btn" @click="addToCart">
          Добавить
        </BaseButton>
      </div>
    </template>
  </BasePopupCenter>
</template>

<script setup>
import BaseButton from "@/components/UI/BaseButton.vue";
import BasePopupCenter from "@/components/UI/BasePopup/BasePopupCenter.vue";
import { computed, ref, watch } from "vue";
import { useCartStore } from "@/stores/cartStore";
import BaseTabs from "@/components/UI/BaseTabs.vue";

const props = defineProps({
  product: {
    type: [Object, null],
    required: true,
  },
  isVisible: {
    type: Boolean,
    default: false,
  },
});

const currentType = ref({});
const currentSize = ref({});

watch(
  () => props.isVisible,
  () => {
    const defaultVariation = props.product.variations[0];
    currentType.value = defaultVariation.type;
    currentSize.value = defaultVariation.size;
  }
);

const currentVariation = computed(() => {
  const { variations } = props.product;

  if (currentType.value) {
    return variations.find(
      ({ type, size }) =>
        type.id === currentType.value.id && size.id === currentSize.value.id
    );
  } else {
    return variations.find(({ size }) => size.id === currentSize.value.id);
  }
});

const productTypeTabs = computed(() => {
  const variationsByCurrentSize = props.product.variations.filter(
    (x) => x.size?.id === currentSize.value?.id
  );

  return getUnique(
    variationsByCurrentSize,
    (x) => x.type?.id,
    (x) => x.type
  );
});

const productSizeTabs = computed(() => {
  const variationsByCurrentType = props.product.variations.filter(
    (x) => x.type?.id === currentType.value?.id
  );

  const sizes = getUnique(
    variationsByCurrentType,
    (x) => x.size.id,
    (x) => x.size
  );

  sizes.forEach((size) => (size.name = `${size.value} ${size.unitName}`));

  return sizes;
});

const getUnique = (array, byUnique, returnValue) => {
  return [...new Map(array.map((x) => [byUnique(x), returnValue(x)])).values()];
};

const emit = defineEmits(["update:isVisible"]);
const cartStore = useCartStore();

const addToCart = () => {
  const currentProduct = {
    ...currentVariation.value,
    name: props.product.name,
    image: props.product.imageSmallUrl,
  };

  cartStore.addToCart(currentProduct);
  emit("update:isVisible", false);
};
</script>

<style lang="scss">
.choose-product-popup {
  width: 1070px;
  padding: 32px 20px 20px 60px;

  @include d-flex($direction: column);
  @include respond-to(xl) {
    width: 900px;
  }
  @include respond-to(lg) {
    width: 700px;
  }

  &__content {
    width: 100%;
    max-width: 480px;

    @include d-flex($direction: column);
    @include respond-to(sm) {
      max-width: none;
      height: 100%;
      overflow-y: auto;
    }
  }

  &__title {
    margin-bottom: 16px;
    font-weight: 600;
    font-size: 20px;
  }

  &__main {
    @include d-flex();

    @include respond-to(sm) {
      flex-direction: column;
      align-items: center;
      width: 100%;
      overflow-y: auto;
    }
  }

  &__img {
    width: 50%;
    max-width: 450px;
    margin-right: 60px;

    @include respond-to(lg) {
      margin-right: 30px;
    }

    @include respond-to(sm) {
      max-width: 260px;
      margin-right: 0;
      margin-bottom: 12px;
    }
  }

  &__footer {
    padding-top: 12px;

    @include d-flex(flex-end, center);
    @include respond-to(sm) {
      justify-content: space-between;
      width: 100%;
      margin-top: auto;
      border-top: 1px solid $light-gray-color;
    }

    &-left {
      margin-right: 20px;

      @include d-flex($align-items: flex-end, $direction: column);
    }
  }

  &__description {
    margin-bottom: 16px;
  }

  &__tabs {
    height: 44px;
    min-height: 44px;
    margin-bottom: 16px;
  }

  &__total-price {
    margin-bottom: 6px;
    color: $primary-color;
    font-weight: 600;
    font-size: 20px;

    @include respond-to(sm) {
      font-size: 16px;
    }
  }

  &__weight {
    color: $gray-color;
    font-size: 14px;
  }

  &__add-btn {
    padding: 0 40px;
  }
}
</style>
