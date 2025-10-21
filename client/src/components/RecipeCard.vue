<script setup>
import { ref } from 'vue'
import { Recipe } from '@/models/Recipe.js'
import ModalWrapper from './ModalWrapper.vue'
import RecipeView from './RecipeView.vue'

const props = defineProps({
    recipe: { type: Recipe, required: true }
})

const modalOpen = ref(false)

function openModal() {
    modalOpen.value = true
}

function closeModal() {
    modalOpen.value = false
}
</script>

<template>
    <ModalWrapper :id="`recipe-modal-${recipe.id}`" :modalHeader="recipe.title" @show="openModal" @hidden="closeModal">
        <!-- Only render when modal is open -->
        <RecipeView v-if="modalOpen" :key="recipe.id" :recipe="recipe" />
    </ModalWrapper>
    <!-- important to add the v-if so our open and close funtions work properly -->

    <div class="card recipe-card">
        <img class="card-img" :src="recipe.img" alt="">
        <div class="box-color m-3 rounded">
            <h3 data-bs-toggle="modal" :data-bs-target="`#recipe-modal-${recipe.id}`">
                {{ recipe.title }}
            </h3>
        </div>
    </div>
</template>



<style lang="scss" scoped>
img {
    width: 100%;
    max-height: 250px;
    object-fit: cover;
}

.box-color {
    position: absolute;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(68, 66, 66, 0.513);
    color: #fff;
    padding: 0.75rem;
    display: flex;
    align-items: flex-end;
    box-sizing: border-box;
}

.category-color {
    position: absolute;
    left: 0;
    right: 0;
    bottom: 10;
    background: rgba(68, 66, 66, 0.513);
    color: #fff;
    display: flex;
    align-items: flex-start;
    box-sizing: border-box;
    max-width: 9vh;
    max-height: 3vh;
    font-size: smaller;
}

.likes-color {
    position: absolute;
    left: 10;
    right: 0;
    bottom: 10;
    background: rgba(68, 66, 66, 0.513);
    color: #fff;
    display: flex;
    align-items: flex-start;
    box-sizing: border-box;
    min-width: 1.5vw;
    min-height: 3vh;
    font-size: smaller;
}



.recipe-card {
    position: relative;
    overflow: hidden;
}

.card-img {
    width: 100%;
    max-height: 250px;
    object-fit: cover;
    display: block;
}
</style>