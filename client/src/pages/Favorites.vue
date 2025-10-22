<script setup>
import { AppState } from '@/AppState.js';
import RecipeCard from '@/components/RecipeCard.vue';
import { favoritesService } from '@/services/FavoritesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const favoriteRecipe = computed(() => AppState.Favorites)

async function getRecipesByAccount() {
    try {
        await favoritesService.getRecipesByAccount()
    }
    catch (error) {
        Pop.error(error);
        logger.error(error)
    }
}

onMounted(getRecipesByAccount)
</script>


<template>
    <section class="row">
        <div class="col-md-4 mt-5" v-for="favorite in favoriteRecipe" :key="favorite.favoriteId">
            <RecipeCard :recipe="favorite.recipe" />
        </div>
    </section>
</template>


<style lang=" scss" scoped></style>
