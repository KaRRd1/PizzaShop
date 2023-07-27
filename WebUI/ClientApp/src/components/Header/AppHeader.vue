<template>
  <header class="header">
    <div
      class="header__content"
      :class="{ fixed: isFixed || isMobileMenuVisible }"
    >
      <div
        v-show="!isFixed || !isTopRowHiddenWhileFixed"
        class="header__row header__row-top"
      >
        <div class="header__top container">
          <div class="header__city">
            <location-icon
              :width="13"
              :height="20"
              class="header__city-icon"
            ></location-icon>
            <span>Санкт-Петербург</span>
          </div>
          <div class="header__top-right">
            <span class="header__working-time">
              Время работы: с 11:00 до 23:00
            </span>
            <base-transparent-button
              v-if="!authStore.isLoggedIn"
              class="header__login"
              @click="isAuthorizationPopupVisible = true"
            >
              <user-icon
                :width="18"
                :height="20"
                class="header__login-icon"
              ></user-icon>
              Войти в аккаунт
            </base-transparent-button>
            <base-dropdown-menu
              v-else
              menu-position="left"
              class="header__account-menu"
              :arrow-is-visible="false"
            >
              <template #title>
                <base-transparent-button class="header__login">
                  <user-icon
                    :width="18"
                    :height="20"
                    class="header__login-icon"
                  ></user-icon>
                  {{ authStore.user.phone }}
                </base-transparent-button>
              </template>
              <template #menu>
                <router-link
                  :to="{ name: 'accountHistory' }"
                  class="header__account-menu-item"
                >
                  История заказов
                </router-link>
                <router-link
                  :to="{ name: 'accountSettings' }"
                  class="header__account-menu-item"
                >
                  Настройки
                </router-link>
                <base-transparent-button
                  class="header__account-menu-item header__account-menu-logout"
                  @click="authStore.logout"
                >
                  Выход из аккаунта
                </base-transparent-button>
              </template>
            </base-dropdown-menu>
          </div>
        </div>
      </div>
      <div class="header__row header__row-bottom">
        <div class="header__bottom container">
          <app-logo
            class="header__logo"
            :class="{ hidden: navIsVisible }"
          ></app-logo>
          <app-logo
            v-show="navIsVisible"
            :is-short="true"
            class="header__logo-short"
          ></app-logo>
          <AppHeaderNav :is-visible="navIsVisible" />
          <base-transparent-button
            v-if="!navIsVisible || !isTopRowHiddenWhileFixed"
            class="header__burger-btn"
            @click="isMobileMenuVisible = !isMobileMenuVisible"
          >
            <burger-icon
              v-if="!isMobileMenuVisible"
              :width="32"
              :height="32"
            ></burger-icon>
            <close-cross-icon
              v-else
              :width="32"
              :height="32"
            ></close-cross-icon>
          </base-transparent-button>
          <base-button class="cart-btn" @click="isCartPopupVisible = true">
            <cart-icon :width="24" :height="24"></cart-icon>
            <span>{{ cartTotalPrice.toLocaleString("ru") }} ₽</span>
          </base-button>
        </div>
      </div>
    </div>
    <div v-show="isFixed || isMobileMenuVisible" class="header__space"></div>
    <cart-popup v-model:is-visible="isCartPopupVisible"></cart-popup>
    <mobile-menu
      v-model:is-visible="isMobileMenuVisible"
      @click-on-login="isAuthorizationPopupVisible = true"
    ></mobile-menu>
    <authorization-popup
      v-model:is-visible="isAuthorizationPopupVisible"
    ></authorization-popup>
  </header>
</template>

<script setup>
import AppLogo from "@/components/AppLogo.vue";
import CartPopup from "@/components/CartPopup/CartPopup.vue";
import MobileMenu from "@/components/MobileMenu.vue";
import BurgerIcon from "@/components/UI/Icons/BurgerIcon.vue";
import CloseCrossIcon from "@/components/UI/Icons/CloseCrossIcon.vue";
import BaseTransparentButton from "@/components/UI/BaseTransparentButton.vue";
import UserIcon from "@/components/UI/Icons/UserIcon.vue";
import BaseDropdownMenu from "@/components/UI/BaseDropdownMenu.vue";
import BaseButton from "@/components/UI/BaseButton.vue";
import AppHeaderNav from "@/components/Header/AppHeaderNav.vue";
import CartIcon from "@/components/UI/Icons/CartIcon.vue";
import { ref, toRefs } from "vue";
import { useCartStore } from "@/stores/cartStore";
import { useAuthStore } from "@/stores/authStore";
import AuthorizationPopup from "@/components/AuthorizationPopup/AuthorizationPopup.vue";
import LocationIcon from "@/components/UI/Icons/LocationIcon.vue";

defineProps({
  navIsVisible: {
    type: Boolean,
    default: true,
  },
  isFixed: {
    type: Boolean,
    default: true,
  },
  isTopRowHiddenWhileFixed: {
    type: Boolean,
    default: false,
  },
});

const isCartPopupVisible = ref(false);
const isMobileMenuVisible = ref(false);
const isAuthorizationPopupVisible = ref(false);

const { cartTotalPrice } = toRefs(useCartStore());
const authStore = useAuthStore();
</script>

<style lang="scss">
.header {
  margin-bottom: 30px;

  &__content {
    position: relative;
    z-index: 1;
    width: 100%;
    background-color: white;

    &.fixed {
      position: fixed;
      top: 0;
    }
  }

  &__row {
    padding: 10px 0;
    border-bottom: 1px solid #f0f0f0;

    &-top {
      height: 41px;
    }

    &-bottom {
      height: 61px;
    }
  }

  &__top {
    font-size: 14px;
    @include d-flex(space-between, center);

    &-right {
      @include d-flex($align-items: center);
    }
  }

  &__city {
    @include d-flex($align-items: center);

    &-icon {
      margin-right: 11px;
      color: $primary-color;
    }
  }

  &__login {
    margin-left: 40px;
    @include d-flex($align-items: center);
    @include respond-to(sm) {
      display: none;
    }

    &:hover {
      text-decoration: underline;
    }

    &-icon {
      margin-right: 10px;
      color: $primary-color;
    }
  }

  &__working-time {
    @include respond-to(sm) {
      display: none;
    }
  }

  &__bottom {
    height: 100%;

    @include d-flex($align-items: center);
  }

  &__logo {
    margin-right: 64px;

    @include respond-to(lg) {
      &.hidden {
        display: none;
      }
    }

    &-short {
      display: none;

      @include respond-to(lg) {
        display: flex;
        margin-right: 14px;
      }
    }
  }

  &__burger-btn {
    display: none;
    margin-left: auto;

    @include respond-to(sm) {
      display: block;
    }
  }

  &__account-menu {
    @include respond-to(sm) {
      display: none;
    }

    &-item {
      margin-bottom: 16px;
      font-size: 16px;
      transition: 0.1s ease-in-out;

      &:hover {
        transform: scale(1.01);
      }
      &:last-child {
        margin-bottom: 0;
      }
    }

    &-bonuses {
      padding-bottom: 16px;
      color: $primary-color;
      font-weight: 600;
      border-bottom: 1px solid $light-gray-color;
    }

    &-logout {
      padding-top: 16px;
      color: $gray-color;
      border-top: 1px solid $light-gray-color;
    }
  }

  &__space {
    height: 102px;
  }
}

.cart-btn {
  height: 40px;
  margin-left: auto;
  padding: 8px 16px;

  @include respond-to(sm) {
    position: fixed;
    right: 20px;
    bottom: 20px;
    width: 56px;
    height: 56px;
    border-radius: 50%;
  }

  svg {
    margin-right: 8px;

    @include respond-to(sm) {
      margin-right: 0;
    }
  }

  span {
    @include respond-to(sm) {
      position: absolute;
      top: 25px;
      right: 36px;
      width: max-content;
      padding: 2px 6px;
      color: $primary-color;
      font-weight: 600;
      background-color: white;
      border: 1px solid $primary-color;
      border-radius: 16px;
    }
  }
}
</style>
