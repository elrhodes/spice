export class Recipe {
    constructor(data) {
        this.id = data.id
        this.createdAt = data.createdAt ? new Date(data.createdAt) : null
        this.updatedAt = data.updatedAt ? new Date(data.updatedAt) : null
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.category = data.category
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}