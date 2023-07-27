import { defineStore } from "pinia";
import { computed, ref, watch } from "vue";

const LS_CART_KEY = "cart";

export const useCartStore = defineStore("cartStore", () => {
  const cartItems = ref(JSON.parse(localStorage.getItem(LS_CART_KEY)) ?? []);

  watch(
    () => cartItems,
    () => localStorage.setItem(LS_CART_KEY, JSON.stringify(cartItems.value)),
    { deep: true }
  );

  const cartTotalPrice = computed(() =>
    cartItems.value.reduce(
      (accum, { quantity, item }) => accum + quantity * item.price,
      0
    )
  );

  const addToCart = (product) => {
    const existedCartItem = cartItems.value.find(
      ({ item }) => item.id === product.id
    );

    if (existedCartItem) existedCartItem.quantity++;
    else cartItems.value.push({ quantity: 1, item: product });
  };

  const getCartItemById = (itemId) =>
    cartItems.value.find((x) => x.item.id === itemId);

  const incrementQuantity = (itemId) => {
    getCartItemById(itemId).quantity++;
  };

  const decrementQuantity = (itemId) => {
    const cartItem = getCartItemById(itemId);

    if (cartItem.quantity > 1) cartItem.quantity--;
    else {
      const cartItemIndex = cartItems.value.indexOf(cartItem);
      cartItems.value.splice(cartItemIndex, 1);
    }
  };

  const clearCart = () => {
    cartItems.value = [];
  };

  return {
    cartItems,
    cartTotalPrice,
    addToCart,
    incrementQuantity,
    decrementQuantity,
    clearCart,
  };
});
