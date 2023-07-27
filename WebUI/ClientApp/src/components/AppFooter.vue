<template>
  <footer class="footer">
    <div class="footer__content container">
      <AppLogo class="footer__logo"></AppLogo>
      <div class="footer__nav">
        <div class="footer__column">
          <h3 class="footer__column-title">{{ appTitle }}</h3>
          <ul>
            <li class="footer__column-item">
              <router-link :to="{ name: 'Company' }">О компании </router-link>
            </li>
            <!--            <li class="footer__column-item">-->
            <!--              <router-link :to="{ name: 'Default' }"-->
            <!--                >Пользовательское соглашение-->
            <!--              </router-link>-->
            <!--            </li>-->
            <!--            <li class="footer__column-item">-->
            <!--              <router-link :to="{ name: 'Default' }"-->
            <!--                >Условия гарантии-->
            <!--              </router-link>-->
            <!--            </li>-->
          </ul>
        </div>
        <div class="footer__column">
          <h3 class="footer__column-title">Помощь</h3>
          <ul>
            <li class="footer__column-item">
              <router-link :to="{ name: 'Delivery' }">Доставка </router-link>
            </li>
            <!--            <li class="footer__column-item">-->
            <!--              <router-link :to="{ name: 'Default' }">Контакты </router-link>-->
            <!--            </li>-->
            <!--            <li class="footer__column-item">-->
            <!--              <router-link :to="{ name: 'Default' }">Поддержка </router-link>-->
            <!--            </li>-->
            <!--            <li class="footer__column-item">-->
            <!--              <router-link :to="{ name: 'Default' }"-->
            <!--                >Отследить заказ-->
            <!--              </router-link>-->
            <!--            </li>-->
          </ul>
        </div>
        <div class="footer__column">
          <h3 class="footer__column-title">Контакты</h3>
          <ul>
            <li class="footer__column-item footer__column-contacts-group">
              <contact-icon :width="20" :height="20"></contact-icon>
              +7 (999) 999-99-99
            </li>
            <li class="footer__column-item footer__column-contacts-group">
              <location-icon :width="14" :height="20"></location-icon>
              Санкт-Петербург, Невский проспект
            </li>
          </ul>
        </div>
      </div>
    </div>
  </footer>
</template>

<script setup>
import AppLogo from "@/components/AppLogo.vue";
import LocationIcon from "@/components/UI/Icons/LocationIcon.vue";
import ContactIcon from "@/components/UI/Icons/ContactIcon.vue";

const appTitle = import.meta.env.VITE_APP_TITLE;
</script>

<style lang="scss">
.footer {
  margin-top: auto;
  padding: 32px 0;
  background: white;
  border: 1px solid #f0f0f0;

  &__content {
    @include d-flex($align-items: flex-start);
    @include respond-to(sm) {
      flex-direction: column;
    }
  }

  &__logo {
    margin-right: 100px;

    @include respond-to(sm) {
      margin-bottom: 24px;
    }
  }

  &__nav {
    flex-wrap: wrap;
    width: 100%;

    @include d-flex(space-between);
    @include respond-to(sm) {
      flex-direction: column;
      flex-wrap: nowrap;
    }
  }

  &__column {
    @include respond-to(sm) {
      margin-bottom: 24px;
    }

    &-title {
      margin-bottom: 22px;
      font-weight: 600;
      font-size: 20px;

      @include respond-to(sm) {
        margin-bottom: 20px;
        font-size: 14px;
      }
    }

    &-item {
      margin-bottom: 20px;
      transition: 0.1s ease-in-out;

      &:hover,
      &:focus {
        color: $primary-color;
      }

      @include respond-to(sm) {
        margin-bottom: 16px;
        font-size: 14px;
      }

      &:last-child {
        margin-bottom: 0;
      }
    }

    &-contacts-group {
      @include d-flex($align-items: center);

      svg {
        margin-right: 15px;
        color: $primary-color;
      }
    }
  }
}
</style>
