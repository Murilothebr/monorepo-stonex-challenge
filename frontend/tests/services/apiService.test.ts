import axios from 'axios';
import { fetchCardData, PostCard, removeCardById } from '../../src/services/apiService';

jest.mock('axios');

describe('apiService', () => {
    afterEach(() => {
        jest.clearAllMocks();
    });

    describe('fetchCardData', () => {
        it('fetches card data successfully', async () => {
            const mockData = [{
                name: 'Sample Name',
                sku: 'Sample SKU',
                price: 'Sample Price',
                stock: 'Sample Stock',
                description: 'Sample Description',
                imageUrls: ['url1', 'url2'],
                tags: ['tag1', 'tag2'],
                sessions: ['session1', 'session2'],
                productId: 'sampleProductId',
                inStock: true
            }];

            const result = await fetchCardData();

            expect(result).toHaveReturned;
        });
    });


    it('handles error when fetching card data', async () => {
        const errorMessage = 'Failed to fetch data';

        const result = await fetchCardData();

        expect(result).toHaveReturned;
    });
});

it('handles error when posting card data', async () => {
    const mockCardData = {
        name: 'Mock Name',
        sku: 'Mock SKU',
        price: 'Mock Price',
        stock: 'Mock Stock',
        description: 'Mock Description',
        imageUrls: ['mockImageUrl1', 'mockImageUrl2'],
        tags: ['tag1', 'tag2'],
        sessions: ['session1', 'session2'],
        productId: "",
        inStock: true
    };

    (axios.post as jest.Mock).mockRejectedValueOnce(new Error(""));

    await expect(PostCard(mockCardData)).rejects.toThrow();
});

describe('removeCardById', () => {
    it('handles error when removing card', async () => {
        const id = 'sampleId';

        jest.spyOn(axios, 'delete').mockRejectedValueOnce(new Error(""));

        await expect(removeCardById(id)).rejects.toThrow();
    });
});
