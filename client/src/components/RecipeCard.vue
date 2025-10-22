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
        <!-- Top bar info -->
        <div class="top-bar">
            <p class="category-color rounded-pill">{{ recipe.category }}</p>
        </div>
        <div class="top-bar-likes">

            <span class="mdi mdi-heart likes-color p-1"></span>
        </div>
        <div class="box-color m-3 rounded">
            <h3 data-bs-toggle="modal" :data-bs-target="`#recipe-modal-${recipe.id}`">
                {{ recipe.title }}
            </h3>
        </div>
    </div>
</template>



<style lang="scss" scoped>
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

.top-bar {
    position: absolute;
    top: 10px;
    left: 10px;
    right: 10px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    z-index: 2;
}

.top-bar-likes {
    position: absolute;
    top: 0px;
    left: 430px;
    right: 10px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    z-index: 2;
}


.category-color {
    background: rgba(68, 66, 66, 0.6);
    color: #fff;
    padding: 0.25rem 0.5rem;
    font-size: smaller;
    border-radius: 9999px;
}

.likes-color {
    color: #fff;
    font-size: 1.25rem;
    background: rgba(68, 66, 66, 0.6);
    padding: 0.3rem;
}
</style>