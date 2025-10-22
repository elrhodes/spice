import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Recipe } from "@/models/Recipe.js"



class FavoritesService {
    async getRecipesByAccount() {
        const response = await api.get("account/favorites")
        logger.log(response.data)
        AppState.Favorites = response.data.map(f => ({
            favoriteId: f.id || f.favoriteId,
            recipe: new Recipe(f)
        }))

    }
}

export const favoritesService = new FavoritesService()