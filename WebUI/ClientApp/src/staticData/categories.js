import PizzaIcon from "@/components/UI/Icons/Categories/PizzaIcon.vue";
import DrinkIcon from "@/components/UI/Icons/Categories/DrinkIcon.vue";
import SnacksIcon from "@/components/UI/Icons/Categories/SnacksIcon.vue";
import DessertIcon from "@/components/UI/Icons/Categories/DessertIcon.vue";
import SauceIcon from "@/components/UI/Icons/Categories/SauceIcon.vue";
import RollsIcon from "@/components/UI/Icons/Categories/RollsIcon.vue";

export const categories = [
  {
    alias: "pizza",
    title: "Пицца",
    icon: PizzaIcon,
  },
  {
    alias: "rolls",
    title: "Роллы",
    icon: RollsIcon,
  },
  {
    alias: "drinks",
    title: "Напитки",
    icon: DrinkIcon,
  },
  {
    alias: "snacks",
    title: "Закуски",
    icon: SnacksIcon,
  },
  {
    alias: "sauces",
    title: "Соусы",
    icon: SauceIcon,
  },
  {
    alias: "dessert",
    title: "Десерты",
    icon: DessertIcon,
  },
];
