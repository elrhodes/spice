<script setup>
import { AppState } from '@/AppState.js';
import { Recipe } from '@/models/Recipe.js';
import { ingredientsService } from '@/services/IngredientsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted, watch } from 'vue';
import { useRoute } from 'vue-router';


const route = useRoute()

const ingredients = computed(() => AppState.ingredients)

async function getIngredients() {
    try {
        await ingredientsService.getIngredients(props.recipe.id)
    }
    catch (error) {
        Pop.error(error);
        logger.error('Could not get ingredients')
    }
}
const props = defineProps({
    recipe: { type: Recipe, required: true },
})

onMounted(getIngredients)

// run every time the recipe changes
watch(() => props.recipe.id, getIngredients)
</script>


<template>
    <section class="row">
        <div class="col-6">
            <img :src="recipe.img" :alt="`a picture of ${recipe.title}`">
        </div>
        <div class="col-6">
            <div class="d-flex justify-space-around gap-2">
                <h2 class="text-green">{{ recipe.title }}e</h2>
                <span class="mdi mdi-dots-horizontal fs-3"></span>
            </div>
            <p>by: {{ recipe.creator.name }}</p>

            <div class="category-color d-flex justify-content-center rounded-pill">{{ recipe.category }}</div>
            <div>
                <div>
                    <h2>Ingredients</h2>
                    <p v-if="!ingredients.length">No ingredients listed</p>
                    <p v-for="ingredient in ingredients" :key="ingredient.id">
                        {{ ingredient.name }} - {{ ingredient.quantity }}
                    </p>
                    <!-- we are performing a check so if there are no ingredients in the array, it does not just show up -->
                </div>
            </div>

            <div>
                <h2>Instructions</h2>
                <ul>
                    <li v-for="(step, index) in recipe.instructions.split(/\d+\.\s*/).filter(s => s)" :key="index">
                        {{ step }}
                    </li>
                </ul>
                <!--Step      What happens	     Result in the ""

1	Take the full string	"1. Mix flour 2. Add sugar 3. Bake"

2	Split by regex /\d+\.\s*/	["", "Mix flour", "Add sugar", "Bake"]

3	Filter out empty strings	["Mix flour", "Add sugar", "Bake"]

4	Loop with v-for	Renders a <li> for each -->

            </div>
        </div>
    </section>
</template>


<style lang="scss" scoped>
img {
    width: 100%;
    height: 100%;
}

.category-color {
    background: rgba(68, 66, 66, 0.513);
    color: #fff;
    display: flex;
    align-items: flex-start;
    box-sizing: border-box;
    max-width: 9vh;
    max-height: 3vh;
    font-size: smaller;
}
</style>