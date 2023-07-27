<template>
  <div class="account-settings-section">
    <div class="account-settings-section__header">
      <h3 class="account-settings-section__title">{{ title }}</h3>
      <base-transparent-button
        v-if="isEditable && !isEdit"
        class="account-settings-section__edit-btn"
        @click="emit('update:isEdit', true)"
      >
        <edit-icon :width="20" :height="20"></edit-icon>
        Изменить
      </base-transparent-button>
    </div>
    <div class="account-settings-section__content">
      <slot />
    </div>
    <div v-if="isEditable && isEdit" class="account-settings-section__footer">
      <base-button
        class="account-settings-section__save-changes"
        @click="saveChanges"
      >
        Сохранить изменения
      </base-button>
    </div>
  </div>
</template>

<script setup>
import BaseTransparentButton from "@/components/UI/BaseTransparentButton.vue";
import EditIcon from "@/components/UI/Icons/EditIcon.vue";
import BaseButton from "@/components/UI/BaseButton.vue";

defineProps({
  title: {
    type: String,
    required: true,
  },
  isEditable: {
    type: Boolean,
    default: false,
  },
  isEdit: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(["update:isEdit", "saveChanges"]);
const saveChanges = () => {
  emit("saveChanges");
};
</script>

<style lang="scss">
.account-settings-section {
  margin-bottom: 20px;
  padding: 24px 32px;
  background-color: white;
  border-radius: $primary-border-radius;

  &__header {
    margin-bottom: 16px;

    @include d-flex(space-between, center);
  }

  &__title {
    @include respond-to(sm) {
      font-size: 18px;
    }
  }

  &__edit-btn {
    color: $primary-color;

    @include d-flex($align-items: center);

    &:hover {
      color: lighten($primary-color, 20%);
    }

    svg {
      margin-right: 12px;
    }
  }

  &__save-changes {
    margin-top: 16px;
    padding: 13px 35px;

    @include respond-to(sm) {
      width: 100%;
    }
  }
}
</style>
