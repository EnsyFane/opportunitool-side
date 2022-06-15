import { HarnessLoader } from '@angular/cdk/testing';
import { MatOptionHarness } from '@angular/material/core/testing';
import { MatSelectHarness } from '@angular/material/select/testing';

export class HomeViewPageObject {
    private element: HTMLElement;
    private loader: HarnessLoader;

    constructor(element: HTMLElement, loader: HarnessLoader) {
        this.element = element;
        this.loader = loader;
    }

    clickLocationDropDown(): void {
        const a = this.element.querySelector('#location-drop-down') as any;
        a.click();
    }

    async getLocationDropDownContents(): Promise<MatOptionHarness[]> {
        const harness = await this.loader.getHarness<MatSelectHarness>(MatSelectHarness.with({ selector: '#location-drop-down' }));
        const options = await harness.getOptions();
        await harness.clickOptions();
        return options;
    }
}
