<script setup>

import { onMounted } from 'vue'

const props = defineProps({
    id: { type: String, required: true },
    modalHeader: { type: String, required: true }
})

const emit = defineEmits(['show', 'hidden'])

onMounted(() => {
    const modalEl = document.getElementById(props.id)
    if (!modalEl) return

    modalEl.addEventListener('show.bs.modal', () => emit('show'))
    modalEl.addEventListener('hidden.bs.modal', () => emit('hidden'))
})

// by adding the show and hide, we can override bootstraps inital request and then rewrite what ingredients we are grabbing.
</script>



<template>
    <div class="modal fade" :id>
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-body">
                    <slot></slot>
                </div>
            </div>
        </div>
    </div>
</template>


<style lang="scss" scoped></style>