<script setup>
import { AppState } from '@/AppState.js';
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
    <section class="row mt-5">
      <div class="col-4 mb-4" v-for="recipe in recipe" :key="'recipeId' + recipe.id">
        <RecipeCard :recipe="recipe" />
      </div>
    </section>
    <div class="row text-end sticky-bottom">
      <b><span class="mdi mdi-plus-circle fs-1 text-green fw-bold"></span></b>
    </div>
  </section>
</template>

<style scoped lang="scss"></style>
