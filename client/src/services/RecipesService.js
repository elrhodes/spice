import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Recipe } from "@/models/Recipe.js"

class RecipesService {
    async getRecipes() {
        AppState.recipes = []
        const response = await api.get('api/recipes')
        logger.log('got the recipe', response.data)
        AppState.recipes = response.data.map(r => new Recipe(r))
    }

}

export const recipesService = new RecipesService()