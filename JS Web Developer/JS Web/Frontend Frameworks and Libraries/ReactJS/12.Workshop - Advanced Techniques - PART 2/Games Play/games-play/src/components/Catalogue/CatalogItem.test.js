import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event'
import { CatalogItem } from './CatalogueItem';
import { BrowserRouter } from 'react-router-dom';

describe('Catalog Item Component', () => {
    test('Show title', () => {
        const title = 'Test Title';

        render(
            <BrowserRouter>
                <CatalogItem _id={'id'} title={title} />
            </BrowserRouter>
        );

        expect(screen.queryByText(title)).toBeInTheDocument()
    });

    test('Click on details', async () => {
        global.window = { location: { pathname: null } };
        const itemId = 'id';

        render(
            <BrowserRouter>
                <CatalogItem _id={itemId} />
            </BrowserRouter>
        );

        await userEvent.click(screen.queryByText('Details'));

        expect(global.window.location.pathname).toContain(`/catalogue/${itemId}`);
    });

});