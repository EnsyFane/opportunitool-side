import { A11yModule } from '@angular/cdk/a11y';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgxSpinnerModule } from 'ngx-spinner';
import { CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID, NgModule } from '@angular/core';
import { OppToolbarModule } from './components/toolbar/toolbar.module';
import { HomeViewComponent } from './components/home-view/home-view.component';
import { OpportunitiesViewComponent } from './components/opportunities-view/opportunities-view.component';
import { OppScrollUpModule } from './components/scroll-up/scroll-up.module';
import { OppHomeViewModule } from './components/home-view/home-view.module';

@NgModule({
    declarations: [
        AppComponent,
        OpportunitiesViewComponent
    ],
    imports: [
        A11yModule,
        AppRoutingModule,
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        CommonModule,
        NgxSpinnerModule,

        OppToolbarModule,
        OppScrollUpModule,
        OppHomeViewModule
    ],
    exports: [],
    providers: [
        {
            provide: LOCALE_ID,
            useValue: navigator.language
        }
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [AppComponent]
})
export class AppModule { }
