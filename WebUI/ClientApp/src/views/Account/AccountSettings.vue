<template>
  <div class="account-settings">
    <account-settings-section
      v-model:is-edit="isPersonalDataEdit"
      title="Личные данные"
      :is-editable="true"
      @save-changes="onPersonalDataSaveChanges"
    >
      <div class="account-settings-personal">
        <base-input-group
          label="Имя*"
          input-id="name"
          class="account-settings-personal__input-group"
          :error-message="v$.name.$errors[0]?.$message"
        >
          <base-input
            id="name"
            v-model="editableUserParams.name"
            class="account-settings-personal__input"
            :empty-as-null="true"
            :is-error="!!v$.name.$errors[0]"
            :disabled="!isPersonalDataEdit"
          ></base-input>
        </base-input-group>
        <base-input-group
          label="Номер телефона*"
          class="account-settings-personal__input-group"
          input-id="phone"
        >
          <base-input
            id="phone"
            :model-value="user.phone"
            class="account-settings-personal__input"
            :disabled="!isPersonalDataEdit"
            readonly
          ></base-input>
        </base-input-group>
        <base-input-group
          label="Почта"
          input-id="email"
          class="account-settings-personal__input-group"
          :error-message="v$.email.$errors[0]?.$message"
        >
          <base-input
            id="email"
            v-model="editableUserParams.email"
            class="account-settings-personal__input"
            :empty-as-null="true"
            :is-error="!!v$.email.$errors[0]"
            :disabled="!isPersonalDataEdit"
          ></base-input>
        </base-input-group>
      </div>
    </account-settings-section>
  </div>
</template>

<script setup>
import AccountSettingsSection from "@/components/Account/AccountSettingsSection.vue";
import BaseInputGroup from "@/components/UI/BaseInputGroup.vue";
import { useAuthStore } from "@/stores/authStore";
import { reactive, ref } from "vue";
import BaseInput from "@/components/UI/BaseInput.vue";
import { updateUserInfo } from "@/api/user";
import { helpers, email, maxLength } from "@vuelidate/validators";
import { useVuelidate } from "@vuelidate/core";

const { user, updateLoggedInUserInfo } = useAuthStore();

const editableUserParams = reactive({
  name: user.name,
  email: user.email,
});

const rules = {
  name: {
    maxLength: helpers.withMessage("Макс. длина 18 символов", maxLength(18)),
  },
  email: {
    email: helpers.withMessage("Неверный формат почты", email),
  },
};

const v$ = useVuelidate(rules, editableUserParams);

const isPersonalDataEdit = ref(false);
const onPersonalDataSaveChanges = async () => {
  if (
    (await v$.value.$validate()) &&
    (await updateUserInfo(editableUserParams))
  ) {
    isPersonalDataEdit.value = false;
    await updateLoggedInUserInfo();
  }
};
</script>

<style lang="scss">
.account-settings {
  &-personal {
    flex-wrap: wrap;
    @include d-flex();

    &__input-group {
      width: auto;
      margin: 0 16px 16px 0;
      @include respond-to(sm) {
        width: 100%;
        margin-right: 0;
      }
    }

    &__input {
      width: 246px;
      @include respond-to(sm) {
        width: 100%;
      }

      &[disabled] {
        padding: 0;
        background-color: transparent;
        border: 0;
      }
    }
  }

  &-bonuses {
    @include d-flex(space-between, center);

    &__amount {
      font-weight: 600;
    }
  }
}
</style>
