<script setup>
import { AppState } from '@/AppState.js';
import ModalWrapper from '@/components/ModalWrapper.vue';
import RecipeCard from '@/components/RecipeCard.vue';
import { recipesService } from '@/services/RecipesService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const recipe = computed(() => AppState.recipes)

onMounted(getRecipes)

async function getRecipes() {
  try {
    await recipesService.getRecipes()
  }
  catch (error) {
    Pop.error(error);
  }
}
</script>

<template>
  <section class="container-fluid mx-0 px-0">
    <!-- Main Header Section -->
    <div class="row  sahitya-regular allSpice position-relative">
      <div class="d-flex flex-column justify-content-center align-items-center font-spice text-white">
        <h1 class="">All-Spice</h1>
        <p>Cherish Your Family</p>
        <p>And Their Cooking</p>
      </div>
      <!-- Starting tabs -->
      <div
        class="col-3 d-flex flex-row justify-content-center align-items-center sahitya-regular absolute gap-3 text-green align-self-end rounded">
        <p>Home</p>
        <p>My Recipes</p>
        <p>Favorites</p>
      </div>
    </div>
  </section>
  <!-- Putting Recipes on the page -->
  <section class="row mt-5">

    <div class="col-4 mb-4" v-for="recipe in recipe" :key="'recipeId' + recipe.id">
      <RecipeCard :recipe="recipe" />
    </div>
  </section>
</template>

<style scoped lang="scss">
.allSpice {
  background-image: url(https://images.unsplash.com/photo-1509358271058-acd22cc93898?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1740);
  min-height: 500px;
  width: 100%;
  background-size: cover;
  background-position: center;
  margin: 0;
}

.font-spice {
  text-shadow: 0 0 10px black, 1px 2px 3px black;
}

.absolute {
  position: absolute;
  left: 74vh;
  bottom: -6%;
  min-height: 60px;
  background-color: white;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.488)
}
</style>
