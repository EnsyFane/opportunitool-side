import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpportunitiesViewComponent } from './opportunities-view.component';

describe('OpportunitiesViewComponent', () => {
    let component: OpportunitiesViewComponent;
    let fixture: ComponentFixture<OpportunitiesViewComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [OpportunitiesViewComponent]
        })
            .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(OpportunitiesViewComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
