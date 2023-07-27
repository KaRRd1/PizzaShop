<template>
  <Teleport to="body">
    <Transition name="mobile-menu-slide">
      <div v-if="isVisible" class="mobile-menu" v-bind="$attrs">
        <div class="mobile-menu__content">
          <div class="mobile-menu__row">
            <div class="container">
              <base-transparent-button
                class="mobile-menu__login"
                @click="onLogin"
              >
                <user-icon
                  :width="20"
                  :height="24"
                  class="mobile-menu__login-icon"
                ></user-icon>
                {{
                  authStore.isLoggedIn
                    ? authStore.user.phone
                    : "Войти в аккаунт"
                }}
              </base-transparent-button>
            </div>
          </div>

          <nav class="mobile-menu__nav">
            <div v-if="authStore.isLoggedIn" class="mobile-menu__row">
              <div class="container">
                <ul>
                  <li class="mobile-menu__nav-item">
                    <router-link :to="{ name: 'accountHistory' }">
                      История заказов
                    </router-link>
                  </li>
                  <li class="mobile-menu__nav-item">
                    <router-link :to="{ name: 'accountSettings' }">
                      Настройки
                    </router-link>
                  </li>
                  <li class="mobile-menu__nav-item">
                    <base-transparent-button
                      class="mobile-menu__account-logout"
                      @click="authStore.logout"
                    >
                      Выход из аккаунта
                    </base-transparent-button>
                  </li>
                </ul>
              </div>
            </div>
            <div class="mobile-menu__row">
              <div class="container">
                <ul>
                  <li class="mobile-menu__nav-item">
                    <router-link :to="{ name: 'Company' }">О компании </router-link>
                  </li>
                  <li class="mobile-menu__nav-item">
                    <router-link :to="{ name: 'Delivery' }">Доставка </router-link>
                  </li>
                </ul>
              </div>
            </div>
          </nav>
          <p class="mobile-menu__working-time">
            Время работы: с 11:00 до 23:00
          </p>
        </div>
      </div>
    </Transition>
  </Teleport>
</template>

<script setup>
import { useAuthStore } from "@/stores/authStore";
import UserIcon from "@/components/UI/Icons/UserIcon.vue";
import BaseTransparentButton from "@/components/UI/BaseTransparentButton.vue";
import { toRef, watch } from "vue";
import { useRoute } from "vue-router";
import { useBodyOverflow } from "@/hooks/useBodyOverflow";

const props = defineProps({
  isVisible: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(["update:isVisible", "clickOnLogin"]);

const route = useRoute();

watch(
  () => route.path,
  () => emit("update:isVisible", false)
);

useBodyOverflow(toRef(props, "isVisible"), "mobile-menu_is-open");

const authStore = useAuthStore();

const onLogin = () => {
  if (!authStore.isLoggedIn) emit('clickOnLogin');
}
</script>

<style lang="scss">
.mobile-menu {
  position: fixed;
  top: 102px;
  bottom: 0;
  display: none;
  width: 100%;
  background-color: white;
  touch-action: none;

  @include respond-to(sm) {
    display: block;
  }

  &_is-open {
    @include respond-to(sm) {
      overflow: hidden;
    }
  }

  &__content {
    height: 100%;
    overflow: auto;
  }

  &__row {
    padding: 20px 0;
    border-bottom: 1px solid #f0f0f0;
  }

  &__login {
    font-size: 16px;
    @include d-flex($align-items: center);

    &-icon {
      margin-right: 16px;
      color: $primary-color;
    }

    &:hover {
      text-decoration: underline;
    }
  }

  &__nav-item {
    margin-bottom: 20px;

    &:last-child {
      margin-bottom: 0;
    }
  }

  &__account-logout {
    color: $gray-color;
    font-size: 14px;
  }

  &__working-time {
    margin: 12px 0;
    color: $gray-color;
    text-align: center;
  }
}

.mobile-menu-slide-enter-active,
.mobile-menu-slide-leave-active {
  transition: transform 0.4s;
}

.mobile-menu-slide-enter-from,
.mobile-menu-slide-leave-to {
  transform: translateX(100%);
}
</style>
