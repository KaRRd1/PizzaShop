module.exports = {
  customSyntax: "postcss-scss",
  extends: [
    "stylelint-config-recommended-scss",
    "stylelint-config-recommended-vue/scss",
    "stylelint-config-rational-order",
  ],
  overrides: [
    {
      files: ["**/*.vue"],
      customSyntax: "postcss-html",
    },
  ],
  plugins: ["stylelint-order", "stylelint-prettier"],
  rules: {
    "declaration-empty-line-before": "never",
    "font-family-name-quotes": "always-unless-keyword",
    "prettier/prettier": true,
    "scss/no-global-function-names": null,
  },
};
