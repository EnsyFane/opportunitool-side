import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'scroll-up',
    templateUrl: './scroll-up.component.html',
    styleUrls: ['./scroll-up.component.scss'],
    animations: [
        trigger('display', [
            state('show', style({
                opacity: 1
            })),
            state('hide', style({
                opacity: 0
            })),
            transition('show => hide', [
                animate('0.3s')
            ]),
            transition('hide => show', [
                animate('0.1s')
            ]),
        ])
    ]
})
export class ScrollUpComponent implements OnInit {
    /**
     * The distance from the top of the page that needs to be traveled to display the button.
     */
    @Input() displayAt: number = 200;

    shouldDisplay = false;

    ngOnInit(): void {
        document.onscroll = () => {
            const doc = document.documentElement;
            this.shouldDisplay = doc.scrollTop > this.displayAt;
        };
    }

    scrollUp(): void {
        document.documentElement.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    }
}
