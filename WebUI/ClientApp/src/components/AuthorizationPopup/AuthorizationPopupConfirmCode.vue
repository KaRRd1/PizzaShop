<template>
  <div class="authorization-popup-confirm-code">
    <base-input
      v-for="(item, index) in localCode"
      :key="index"
      ref="codeInputs"
      v-model="localCode[index]"
      v-maska
      data-maska="#"
      class="authorization-popup-confirm-code-input"
      type="text"
      inputmode="numeric"
      placeholder="X"
      @input="onCodeInput"
    ></base-input>
  </div>
</template>

<script setup>
import BaseInput from "@/components/UI/BaseInput.vue";
import { vMaska } from "maska";
import { ref } from "vue";

const props = defineProps({
  code: {
    type: Array,
    required: true,
  },
});

const codeInputs = ref(null);
const localCode = ref(props.code);

const onCodeInput = (e) => {
  const value = e.target.value;

  if (value !== "") {
    const emptyFieldIndex = localCode.value.indexOf("");
    if (emptyFieldIndex !== -1) {
      codeInputs.value[emptyFieldIndex].$el.focus();
    }
  }
};
</script>

<style lang="scss">
.authorization-popup-confirm-code {
  width: 100%;
  margin-bottom: 16px;
  @include d-flex(space-between);

  &-input {
    width: 48px;
    padding: 16px 18.5px;
  }
}
</style>
