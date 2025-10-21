import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Ingredient } from "@/models/Ingredient.js"

class IngredientsService {

    async getIngredients(recipeId) {
        AppState.ingredients = []
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('got ingredient', response.data)
        AppState.ingredients = response.data.map((i) => new Ingredient(i))
    }
}

export const ingredientsService = new IngredientsService()