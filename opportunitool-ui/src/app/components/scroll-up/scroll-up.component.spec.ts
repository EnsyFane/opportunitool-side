import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatIconModule } from '@angular/material/icon';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { ScrollUpComponent } from './scroll-up.component';

describe('ScrollUpComponent', () => {
    let component: ScrollUpComponent;
    let fixture: ComponentFixture<ScrollUpComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [ScrollUpComponent],
            imports: [
                MatIconModule,
                NoopAnimationsModule
            ]
        }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(ScrollUpComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
