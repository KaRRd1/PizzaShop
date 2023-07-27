module.exports = {
    env: {
        "node": true, 
        "vue/setup-compiler-macros": true
    },
    extends: [
        "plugin:vue/vue3-essential",
        "plugin:vue/vue3-strongly-recommended",
        "plugin:vue/vue3-recommended",
        "eslint:recommended",
        "plugin:prettier/recommended",
    ],
    rules: {
        "vue/multi-word-component-names": 0,
        "prettier/prettier": 0,
    }
}